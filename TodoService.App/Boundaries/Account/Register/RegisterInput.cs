namespace App.Boundaries.Account.Register
{
    public class RegisterInput
    {
        public RegisterInput(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }
}
