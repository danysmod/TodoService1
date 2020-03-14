namespace TodoService.Domain
{
    using System.Threading.Tasks;

    public interface ITableRepository
    {
        Task<ITable> GetTableAsync(BaseEntityId tableId, BaseEntityId accountId);

        Task AddTaskAsync(ITableTask task);

        Task AddTableAsync(ITable table);

        Task<ITableTask> GetTaskAsync(BaseEntityId tableId, BaseEntityId accountId, BaseEntityId taskId);

        Task Update(ITable table);

        Task Update(ITableTask task);
    }
}
