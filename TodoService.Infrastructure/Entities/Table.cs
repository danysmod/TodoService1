namespace TodoService.Infrastructure.Entities
{
    using Domain;
    using System;
    using System.Collections.Generic;

    public class Table : Domain.Table
    {
        public Table(TableTitle tableName, IAccount account)
        {
            Id = new BaseEntityId(Guid.NewGuid());
            Name = tableName;
            CreateDate = DateTime.Now;
            AccountId = account.Id;
            State = TableState.Actual;
            Tasks = new TableTaskCollection();
        }

        protected Table()
        {

        }

        public void Load(IList<TableTask> tasks)
        {
            Tasks = new TableTaskCollection();
            Tasks.Add(tasks);
        }

        public BaseEntityId AccountId { get; protected set; }
    }
}
