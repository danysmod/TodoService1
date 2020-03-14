namespace App.Boundaries.Account.GetAccountDetails
{
    using TodoService.Domain;
    using TodoService.Identity;

    public sealed class GetAccountDetailsOutput
    {
        public GetAccountDetailsOutput(IAccount account, ApplicationUser user)
        {
            Account = (Account)account;
            Username = user.UserName;
        }

        public string Username { get; }

        public Account Account { get; }
    }
}
