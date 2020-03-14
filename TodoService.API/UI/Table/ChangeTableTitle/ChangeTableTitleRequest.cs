using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.ChangeTableTitle
{
    public class ChangeTableTitleRequest
    {
        [Required]
        public Guid TableId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
