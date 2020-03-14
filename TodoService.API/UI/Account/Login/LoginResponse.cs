using API.ViewModels;
using TodoService.Identity;

namespace API.UI.Account
{
    public sealed class LoginResponse
    {
        public LoginResponse(string token, string accountId)
        {
            Token = token;
            AccountId = accountId;
        }

        public string Token { get; }

        public string AccountId { get; }
    }
}
