using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Application.Dto
{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; }
    }
}
