using System.ComponentModel.DataAnnotations;
﻿using ToDoApp.Domain.Models.Base;

namespace ToDoApp.Domain.Models
{
    public class ToDoTask : EntityBase
    {
        [Required]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
