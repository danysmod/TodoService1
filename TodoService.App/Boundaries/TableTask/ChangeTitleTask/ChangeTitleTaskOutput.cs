using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.TableTask.ChangeTitleTask
{
    using TodoService.Domain;
    
    public sealed class ChangeTitleTaskOutput
    {
        public ChangeTitleTaskOutput(ITableTask tableTask)
        {
            TableTask = (TableTask)tableTask;
        }

        public TableTask TableTask { get; }
    }
}
