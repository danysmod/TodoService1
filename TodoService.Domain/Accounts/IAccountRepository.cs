namespace TodoService.Domain
{
    using System.Threading.Tasks;

    public interface IAccountRepository
    {
        Task Add(IAccount account);
    }
}
