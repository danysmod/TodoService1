namespace TodoService.Domain
{
    using System;
    using System.Collections.Generic;

    public sealed class TableTaskCollection
    {
        private readonly IList<ITableTask> tasks;

        public TableTaskCollection()
        {
            this.tasks = new List<ITableTask>();
        }

        public void Add<T>(IEnumerable<T> tasks)
            where T : ITableTask
        {
            if(tasks is null)
            {
                throw new Exception("");
            }

            foreach(var task in tasks)
            {
                if(task is null)
                {
                    throw new Exception("");
                }

                this.tasks.Add(task);
            }
        }

        public void Add(ITableTask task) => this.tasks.Add(task);
    }
}
