using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync(string userId);
        Task<TaskItem?> GetTaskByIdAsync(int id, string userId);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task, string userId);
        Task<bool> DeleteTaskAsync(int id, string userId);
    }
}

