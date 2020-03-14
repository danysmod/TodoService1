using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.DeleteTable
{
    public sealed class DeleteTableResponse
    {
        public DeleteTableResponse(Guid tableId)
        {
            TableId = tableId;
        }

        public Guid TableId { get; }
    }
}
