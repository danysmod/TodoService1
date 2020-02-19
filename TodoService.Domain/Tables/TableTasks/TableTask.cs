namespace TodoService.Domain
{
    public class TableTask : BaseEntity, ITableTask
    {
        public TaskText Text { get; protected set; }
        public TaskState State { get; protected set; }

        public void Delete()
        {
            State = TaskState.Deleted;
        }

        public void Complete()
        {
            State = TaskState.Completed;
        }
    }
}