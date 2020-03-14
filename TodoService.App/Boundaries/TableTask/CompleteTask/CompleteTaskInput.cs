using System;
using System.Collections.Generic;
using System.Text;
using TodoService.Domain;

namespace App.Boundaries.TableTask.CompleteTask
{
    public sealed class CompleteTaskInput
    {
        public CompleteTaskInput(BaseEntityId accountId, BaseEntityId tableId, BaseEntityId taskId)
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
