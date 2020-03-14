using System;
using System.Collections.Generic;
using System.Text;
using TodoService.Domain;

namespace App.Boundaries.Table.DeleteTable
{
    public sealed class DeleteTableOutput
    {
        public DeleteTableOutput(ITable table)
        {
            TableId = table.Id;
        }

        public BaseEntityId TableId;
    }
}
