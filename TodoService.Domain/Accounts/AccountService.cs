namespace TodoService.Domain
{
    using System.Threading.Tasks;

    public class AccountService
    {
        private readonly IAccountFactory accountFactory;
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountFactory factory,
                              IAccountRepository repository)
        {
            accountFactory = factory;
            accountRepository = repository;
        }

        public async Task<IAccount> CreateAccountAsync()
        {
            var account = accountFactory.NewAccount();
            await accountRepository.Add(account);
            return account;
        }
    }
}
