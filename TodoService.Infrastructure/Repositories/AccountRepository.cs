namespace TodoService.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using Account = Entities.Account;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly TodoServiceContext context;

        public AccountRepository(TodoServiceContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(IAccount account)
        {
            await context.Accounts.AddAsync((Account)account);
        }

        public async Task<IAccount> GetAccountAsync(BaseEntityId id)
        {
            var account = await context.Accounts
                .Where(x => x.Id.Equals(id))
                .SingleOrDefaultAsync();

            if(account is null)
            {
                throw new Exception("");
            }

            var tables = await context.Tables
                .Where(e => e.AccountId.Equals(id) && e.State != TableState.Deleted)
                .ToListAsync();

            account.Load(tables);

            return account;
        }
    }
}
