namespace TodoService.Domain
{
    public interface ITableTask
    {
        BaseEntityId Id { get; }

        TaskText Text { get; }

        TaskState State { get; }

        ITableTask Complete();

        ITableTask Delete();

        ITableTask ChangeTitle(TaskText title);
    }
}