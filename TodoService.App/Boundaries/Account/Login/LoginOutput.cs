namespace App.Boundaries.Account.Login
{
    using TodoService.Domain;
    using TodoService.Identity;

    public sealed class LoginOutput
    {
        public LoginOutput(string token, ApplicationUser applicationUser)
        {
            Token = token;
            AccountId = applicationUser.AccountId.ToString();
        }

        public string AccountId { get; }

        public string Token { get; }
    }
}
