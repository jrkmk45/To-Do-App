using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Application.Dto
{
    public class CreateTaskDto
    {
        [Required, MaxLength(250)]
        public string Title { get; set; }
    }
}
