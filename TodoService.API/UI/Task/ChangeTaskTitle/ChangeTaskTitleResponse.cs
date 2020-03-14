using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.ChangeTaskTitle
{
    public sealed class ChangeTaskTitleResponse
    {
        public ChangeTaskTitleResponse(TableTaskModel tableTask)
        {
            TableTask = tableTask;
        }

        public TableTaskModel TableTask { get; }
    }
}
