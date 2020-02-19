namespace TodoService.Infrastructure
{
    using System.Threading.Tasks;
    using TodoService.Domain;
    using Account = Entities.Account;

    public class AccountRepository : IAccountRepository
    {
        private readonly TodoServiceContext context;

        public AccountRepository(TodoServiceContext context)
        {
            this.context = context;
        }

        public async Task Add(IAccount account)
        {
            await context.Accounts.AddAsync((Account)account);
            await context.SaveChangesAsync();
        }
    }
}
