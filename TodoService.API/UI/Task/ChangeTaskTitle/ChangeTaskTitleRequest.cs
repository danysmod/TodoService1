using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.ChangeTaskTitle
{
    public sealed class ChangeTaskTitleRequest
    {
        [Required]
        public Guid TaskId { get; set; }

        [Required]
        public Guid TableId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
