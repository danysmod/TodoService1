namespace App.Boundaries.Account.Register
{
    using TodoService.Domain;
    using TodoService.Identity;

    public sealed class RegisterOutput
    {
        public RegisterOutput(string token, IAccount account, ApplicationUser applicationUser)
        {
            Token = token;
            Account = (Account)account;
            UserName = applicationUser.UserName;
        }

        public string Token { get; }

        public string UserName { get; }

        public Account Account { get; }
    }
}
