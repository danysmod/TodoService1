namespace App.Boundaries.Account.Login
{
    public sealed class LoginInput
    {
        public LoginInput(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}
