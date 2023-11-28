using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Repository.Interfaces;
using ToDoApp.Domain.Models;

namespace ToDoApp.DAL.Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoAppDbContext _dbContext;
        public TaskRepository(ToDoAppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<ToDoTask?> GetTaskAsync(Guid taskId)
        {
            return _dbContext.Tasks.SingleOrDefaultAsync(t => t.Id == taskId);
        }

        public Task<List<ToDoTask>> GetTasksAsync()
        {
            return _dbContext.Tasks.OrderByDescending(t => t.DateCreated).ToListAsync();
        }

        public Task<List<ToDoTask>> GetTasksAsync(string title)
        {
            return _dbContext.Tasks.Where(t => t.Title.ToLower().Contains(title.ToLower()))
                .OrderByDescending(t => t.DateCreated)
                .ToListAsync();
        }

        public Task CreateTaskAsync(ToDoTask task)
        {
            _dbContext.Tasks.Add(task);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateTaskAsync(ToDoTask task)
        {
            _dbContext.Update(task);
            return _dbContext.SaveChangesAsync();
        }

        public Task RemoveTaskAsync(ToDoTask task)
        {
            _dbContext.Remove(task);
            return _dbContext.SaveChangesAsync();
        }
    }
}
