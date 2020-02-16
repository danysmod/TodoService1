namespace TodoService.Domain
{
    using System.Threading.Tasks;

    public interface ITableRepository
    {
        Task<ITable> GetTable(BaseEntityId entityId);

        Task AddTask(ITableTask task);
    }
}
