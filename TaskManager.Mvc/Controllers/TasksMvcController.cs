using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using TaskManager.Mvc.Models;

namespace TaskManager.Mvc.Controllers
{
    public class TasksMvcController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5219/api/tasks";

        public TasksMvcController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            try 
            {
                var tasks = await _httpClient.GetFromJsonAsync<IEnumerable<TaskItem>>(_apiBaseUrl);
                return View(tasks);
            }
            catch (Exception)
            {
                // In case API is not running, return empty list for now
                return View(new List<TaskItem>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _httpClient.GetFromJsonAsync<TaskItem>($"{_apiBaseUrl}/{id}");
            if (task == null) return NotFound();
            return View(task);
        }
    }
}
