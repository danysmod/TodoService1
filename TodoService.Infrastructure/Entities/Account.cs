namespace TodoService.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using TodoService.Domain;

    public class Account : Domain.Account
    {
        public Account()
        {
            Id = new BaseEntityId(Guid.NewGuid());
            CreateDate = DateTime.Now;
        }

        public void Load(IList<Table> tables)
        {
            Tables = new TableCollection();
            Tables.Add(tables);
        }
    }
}
