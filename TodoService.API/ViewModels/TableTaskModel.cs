using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class TableTaskModel
    {
        public TableTaskModel(Guid taskId, string title, int state)
        {
            TaskId = taskId;
            Title = title;
            State = state;
        }

        public Guid TaskId { get; }

        public string Title { get; }

        public int State { get; }
    }
}
