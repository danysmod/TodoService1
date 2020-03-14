using API.ViewModels;
using TodoService.Identity;

namespace API.UI.Account
{
    public sealed class RegisterResponse
    {
        public RegisterResponse(string token, AccountDetailsModel accountDetails)
        {
            Token = token;
            AccountDetails = accountDetails;
        }

        public string Token { get; }

        public AccountDetailsModel AccountDetails { get; }
    }
}
