using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApp.Application.Dto;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Interfaces;
using ToDoApp.Web.ViewModels;

namespace ToDoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskService _taskService;
        public TasksController(ILogger<TasksController> logger,
            ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetTasksAsync();
            return View(new ToDoViewModel
            {
                Tasks = tasks,
            });
        }

        [HttpGet("tasks")]
        public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetTasks([FromQuery] string? title)
        {
            var tasks = await _taskService.GetTasksAsync(title);
            return Ok(tasks);
        }

        [HttpPost("tasks")]
        public async Task<ActionResult<ToDoTaskDto>> CreateTask([FromBody] CreateTaskDto newTask)
        {
            var task = await _taskService.CreateTaskAsync(newTask);
            return CreatedAtAction(nameof(GetTasks), task);
        }

        [HttpDelete("tasks/{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                await _taskService.RemoveTaskAsync(id);
            }
            catch (EntityNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpPatch("tasks/{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] PatchTaskDto task)
        {
            try
            {
                await _taskService.UpdateTaskAsync(id, task);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}