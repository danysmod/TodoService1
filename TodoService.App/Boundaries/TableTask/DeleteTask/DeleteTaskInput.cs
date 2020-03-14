using System;
using System.Collections.Generic;
using System.Text;
using TodoService.Domain;

namespace App.Boundaries.TableTask.DeleteTask
{
    public sealed class DeleteTaskInput
    {
        public DeleteTaskInput(BaseEntityId accountId, BaseEntityId tableId, BaseEntityId taskId)
        {
            AccountId = accountId;
            TableId = tableId;
            TaskId = taskId;
        }

        public BaseEntityId AccountId { get; }

        public BaseEntityId TableId { get; }

        public BaseEntityId TaskId { get; }
    }
}
