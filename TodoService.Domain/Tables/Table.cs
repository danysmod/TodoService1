namespace TodoService.Domain
{
    public class Table : BaseEntity, ITable 
    {
        public TableName Name { get; protected set; }

        public TableTaskCollection Tasks { get; protected set; }

        public ITableTask AddTask(ITableFactory tableFactory, TaskText taskText)
        {
            var task = tableFactory.NewTask(this, taskText);
            Tasks.Add(task);
            return task;
        }
    }
}
