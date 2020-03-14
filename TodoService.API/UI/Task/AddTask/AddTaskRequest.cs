using System;
using System.ComponentModel.DataAnnotations;

namespace API.UI.Task.AddTask
{
    public sealed class AddTaskRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Guid TableId { get; set; }
    }
}
