using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(string userId)
        {
            var query = _context.TaskItems.AsQueryable();
            
            if (!string.IsNullOrEmpty(userId))
            {
                query = query.Where(t => t.UserId == userId);
            }

            return await query
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }


        public async Task<TaskItem?> GetTaskByIdAsync(int id, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            }
            return await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }


        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task, string userId)
        {
            var existingTask = await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.DueDate = task.DueDate;

            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int id, string userId)
        {
            var task = await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            
            if (task == null) return false;

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

