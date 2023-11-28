using ToDoApp.Domain.Models;

namespace ToDoApp.DAL.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<ToDoTask?> GetTaskAsync(Guid taskId);
        Task<List<ToDoTask>> GetTasksAsync();
        Task<List<ToDoTask>> GetTasksAsync(string title);
        Task CreateTaskAsync(ToDoTask task);
        Task UpdateTaskAsync(ToDoTask task);
        Task RemoveTaskAsync(ToDoTask task);
    }
}
