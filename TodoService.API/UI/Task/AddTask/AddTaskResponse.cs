using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.AddTask
{
    public sealed class AddTaskResponse 
    {
        public AddTaskResponse(TableTaskModel tableTask)
        {
            TableTask = tableTask;
        }

        public TableTaskModel TableTask { get; }
    }
}
