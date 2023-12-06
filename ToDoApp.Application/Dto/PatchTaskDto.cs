using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Application.Dto
{
    public class PatchTaskDto
    {
        [MaxLength(250)]
        public string? Title { get; set; }
        public bool? isCompleted { get; set; }
    }
}
