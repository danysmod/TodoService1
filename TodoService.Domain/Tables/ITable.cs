namespace TodoService.Domain
{
    public interface ITable
    {
        BaseEntityId Id { get; }
        ITableTask AddTask(ITableFactory tableFactory, TaskText taskText);
    }
}
