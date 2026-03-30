using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(string userId)
        {
            return await _repository.GetAllTasksAsync(userId);
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id, string userId)
        {
            return await _repository.GetTaskByIdAsync(id, userId);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            return await _repository.CreateTaskAsync(task);
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task, string userId)
        {
            return await _repository.UpdateTaskAsync(id, task, userId);
        }

        public async Task<bool> DeleteTaskAsync(int id, string userId)
        {
            return await _repository.DeleteTaskAsync(id, userId);
        }
    }
}

