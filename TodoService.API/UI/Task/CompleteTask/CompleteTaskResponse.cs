using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.CompleteTask
{
    public sealed class CompleteTaskResponse
    {
        public CompleteTaskResponse(TableTaskModel tableTask)
        {
            TableTask = tableTask;
        }

        public TableTaskModel TableTask { get; }
    }
}
