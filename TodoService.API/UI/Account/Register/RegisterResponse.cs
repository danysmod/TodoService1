using TodoService.Identity;

namespace API.UI.Account.Register
{
    public sealed class RegisterResponse
    {
        public RegisterResponse(ApplicationUser user)
        {
            User = user;
        }

        public ApplicationUser User;
    }
}
