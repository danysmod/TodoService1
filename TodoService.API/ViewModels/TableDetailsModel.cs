using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class TableDetailsModel
    {
        public TableDetailsModel(string title, Guid tableId, int state, List<TableTaskModel> tasks)
        {
            Title = title;
            Tasks = tasks;
            TableId = tableId;
            State = state;
        }

        public Guid TableId { get; }

        public string Title { get; }

        public int State { get; }

        public List<TableTaskModel> Tasks { get; }
    }
}
