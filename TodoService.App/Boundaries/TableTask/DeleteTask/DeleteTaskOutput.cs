using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.TableTask.DeleteTask
{ 
    using TodoService.Domain;

    public sealed class DeleteTaskOutput
    {
        public DeleteTaskOutput(ITableTask tableTask)
        {
            TaskId = tableTask.Id;
        }

        public BaseEntityId TaskId { get; }
    }
}
