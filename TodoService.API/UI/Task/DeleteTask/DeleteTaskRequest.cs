using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.DeleteTask
{
    public sealed class DeleteTaskRequest
    {
        [Required]
        public Guid TaskId { get; set; }

        [Required]
        public Guid TableId { get; set; }
    }
}
