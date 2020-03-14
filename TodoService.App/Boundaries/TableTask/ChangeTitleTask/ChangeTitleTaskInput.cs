using System;
using System.Collections.Generic;
using System.Text;
using TodoService.Domain;

namespace App.Boundaries.TableTask.ChangeTitleTask
{
    public sealed class ChangeTitleTaskInput
    {
        public ChangeTitleTaskInput(BaseEntityId accountId, BaseEntityId tableId, BaseEntityId taskId, TaskText title)
        {
            AccountId = accountId;
            TableId = tableId;
            TaskId = taskId;
            Title = title;
        }

        public BaseEntityId AccountId { get; }

        public BaseEntityId TableId { get; }

        public BaseEntityId TaskId { get; }

        public TaskText Title { get; }
    }
}
