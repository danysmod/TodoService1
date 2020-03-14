using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.DeleteTable
{
    public sealed class DeleteTableRequest
    {
        [Required]
        public Guid TableId { get; set; }
    }
}
