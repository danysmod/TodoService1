namespace App.Boundaries.Account.Register
{
    public sealed class RegisterInput
    {
        public RegisterInput(string email, string password, string username)
        {
            Email = email;
            Password = password;
            UserName = username;
        }

        public string Email { get; }

        public string UserName { get; }

        public string Password { get; }
    }
}
