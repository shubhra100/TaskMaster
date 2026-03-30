using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Api.Models;
using TaskManager.Api.Services;

namespace TaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var tasks = await _service.GetAllTasksAsync(UserId);
            return Ok(tasks);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _service.GetTaskByIdAsync(id, UserId);
            if (task == null) return NotFound();
            return Ok(task);
        }


        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            task.UserId = UserId;
            var createdTask = await _service.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedTask = await _service.UpdateTaskAsync(id, task, UserId);
            if (updatedTask == null) return NotFound();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _service.DeleteTaskAsync(id, UserId);
            if (!deleted) return NotFound();
            
            return NoContent();
        }
    }
}

