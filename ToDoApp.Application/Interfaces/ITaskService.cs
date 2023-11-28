using ToDoApp.Application.Dto;

namespace ToDoApp.Application.Interfaces
{
    public interface ITaskService
    {
        public Task<List<ToDoTaskDto>> GetTasksAsync(string? title = null);
        public Task<ToDoTaskDto> CreateTaskAsync(CreateTaskDto task);
        public Task UpdateTaskAsync(Guid taskId, PatchTaskDto task);
        public Task RemoveTaskAsync(Guid taskId);
    }
}
