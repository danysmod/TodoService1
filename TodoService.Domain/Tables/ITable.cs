using System.Collections.Generic;

namespace TodoService.Domain
{
    public interface ITable
    {
        BaseEntityId Id { get; }

        TableTitle Name { get; }

        TableState State { get; }

        ITableTask AddTask(ITableFactory tableFactory, TaskText taskText);

        IList<ITableTask> GetTasks();

        ITable ChangeName(TableTitle name);

        ITable Delete();
    }
}
