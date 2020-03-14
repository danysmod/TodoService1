using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public sealed class TableModel
    {
        public TableModel(string title, Guid tableId)
        {
            TableId = tableId;
            Title = title;
        }

        public string Title { get; }

        public Guid TableId { get; }
    }
}
