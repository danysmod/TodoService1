namespace TodoService.Domain
{
    using System.Threading.Tasks;

    public interface IAccountRepository
    {
        Task AddAsync(IAccount account);

        Task<IAccount> GetAccountAsync(BaseEntityId id);
    }
}
