namespace TodoService.Domain.Services
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
