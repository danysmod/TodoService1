using System.Collections.Generic;

namespace TodoService.Domain
{
    public class Table : BaseEntity, ITable 
    {
        public TableTitle Name { get; protected set; }

        public TableTaskCollection Tasks { get; protected set; }

        public TableState State { get; protected set; }

        public ITableTask AddTask(ITableFactory tableFactory, TaskText taskText)
        {
            var task = tableFactory.NewTask(this, taskText);
            Tasks.Add(task);
            return task;
        }

        public IList<ITableTask> GetTasks() => Tasks.GetTasks();

        public ITable ChangeName(TableTitle name)
        {
            Name = name;
            return this;
        }

        public ITable Delete()
        {
            State = TableState.Deleted;

            return this;
        }
    }
}
