using AutoMapper;
using ToDoApp.Application.Dto;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Interfaces;
using ToDoApp.DAL.Repository.Interfaces;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository,
            IMapper mapper) 
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<ToDoTaskDto>> GetTasksAsync(string? title = null)
        {
            List<ToDoTask> taskList;
            if (title == null)
                taskList = await _taskRepository.GetTasksAsync();
            else
                taskList = await _taskRepository.GetTasksAsync(title.Trim());

            return _mapper.Map<List<ToDoTaskDto>>(taskList);
        }

        public async Task<ToDoTaskDto> CreateTaskAsync(CreateTaskDto task)
        {
            var mappedTask = _mapper.Map<ToDoTask>(task);

            mappedTask.DateCreated = DateTimeOffset.Now;
            await _taskRepository.CreateTaskAsync(mappedTask);

            return _mapper.Map<ToDoTaskDto>(mappedTask);
        }

        public async Task UpdateTaskAsync(Guid taskId, PatchTaskDto task)
        {
            var existingTask = await _taskRepository.GetTaskAsync(taskId);
            if (existingTask == null)
                throw new EntityNotFoundException(taskId);

            _mapper.Map(task, existingTask);
            existingTask.Id = taskId;

            await _taskRepository.UpdateTaskAsync(existingTask);
        }

        public async Task RemoveTaskAsync(Guid taskId)
        {
            var task = await _taskRepository.GetTaskAsync(taskId);
            if (task == null)
                throw new EntityNotFoundException(taskId);

            await _taskRepository.RemoveTaskAsync(task);
        }
    }
}
