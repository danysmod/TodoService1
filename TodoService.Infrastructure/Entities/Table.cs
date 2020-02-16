namespace TodoService.Infrastructure.Entities
{
    using Domain;
    using System;
    using System.Collections.Generic;

    public class Table : Domain.Table
    {
        public Table(TableName tableName)
        {
            Id = new BaseEntityId(Guid.NewGuid());
            Name = tableName;
        }

        protected Table()
        {

        }

        public void LoadTasks(IList<TableTask> tasks)
        {
            Tasks = new TableTaskCollection();
            Tasks.Add(tasks);
        }
    }
}
