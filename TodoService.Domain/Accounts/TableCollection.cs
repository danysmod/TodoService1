namespace TodoService.Domain
{
    using System;
    using System.Collections.Generic;
    
    public sealed class TableCollection
    {
        private readonly IList<ITable> tables;

        public TableCollection()
        {
            tables = new List<ITable>();
        }

        public void Add<T>(IEnumerable<T> tasks)
            where T : ITable
        {
            if (tasks is null)
            {
                throw new Exception("");
            }

            foreach (var task in tasks)
            {
                if (task is null)
                {
                    throw new Exception("");
                }

                tables.Add(task);
            }
        }

        public void Add(ITable task) => tables.Add(task);
    }
}
