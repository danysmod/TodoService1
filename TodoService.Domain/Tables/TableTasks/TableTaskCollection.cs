namespace TodoService.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

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

        public IList<ITableTask> GetTasks() => new List<ITableTask>(tasks);

        public IList<ITableTask> Delete()
        {
            foreach(var task in tasks)
            {
                task.Delete();
            }

            return this.tasks;
        }
    }
}
