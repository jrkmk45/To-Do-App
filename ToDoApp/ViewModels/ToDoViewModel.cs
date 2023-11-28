using ToDoApp.Application.Dto;

namespace ToDoApp.Web.ViewModels
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoTaskDto> Tasks { get; set; }
    }
}
