namespace App.Boundaries.Account.Register
{
    using TodoService.Identity;

    public class RegisterOutput
    {
        public RegisterOutput(ApplicationUser user)
        {
            User = user;
        }

        public ApplicationUser User { get; }
    }
}
