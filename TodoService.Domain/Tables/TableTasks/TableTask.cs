using System;

namespace TodoService.Domain
{
    public class TableTask : BaseEntity, ITableTask
    {
        public TaskText Text { get; protected set; }
        public TaskState State { get; protected set; }

        public ITableTask Delete()
        {
            State = TaskState.Deleted;
            return this;
        }

        public ITableTask Complete()
        {
            State = TaskState.Completed;
            return this;
        }

        public ITableTask ChangeTitle(TaskText title)
        {
            Text = title;
            return this;
        }
    }
}