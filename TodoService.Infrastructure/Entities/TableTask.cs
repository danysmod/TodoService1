namespace TodoService.Infrastructure.Entities
{
    using Domain;
    using System;

    public class TableTask : Domain.TableTask
    {
        public TableTask(ITable table, TaskText taskText)
        {
            TableId = table.Id;
            Id = new BaseEntityId(Guid.NewGuid());
            Text = taskText;
        }

        protected TableTask()
        {

        }

        public BaseEntityId TableId { get; protected set; }
    }
}
