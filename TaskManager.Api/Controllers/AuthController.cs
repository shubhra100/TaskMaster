using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Api.Data;
using TaskManager.Api.Models;
using BCrypt.Net;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto request)
        {
            if (_context.Users.Any(u => u.Username == request.Username))
            {
                return BadRequest(new AuthResponseDto { Success = false, Message = "Username already exists." });
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseDto 
            { 
                Success = true, 
                Message = "User registered successfully!",
                Token = CreateToken(user),
                Username = user.Username 
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest(new AuthResponseDto { Success = false, Message = "Invalid username or password." });
            }

            return Ok(new AuthResponseDto
            {
                Success = true,
                Message = "Login successful!",
                Token = CreateToken(user),
                Username = user.Username
            });
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Using a hardcoded key for simplicity in this demo. 
            // In production, this should be a long string in appsettings.json
            var keyStr = _configuration.GetSection("AppSettings:Token").Value ?? "THIS_IS_A_VERY_LONG_AND_SECURE_SECRET_KEY_FOR_JWT_TOKEN_GENERATION_64_CHARS_LONG_!!!";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
