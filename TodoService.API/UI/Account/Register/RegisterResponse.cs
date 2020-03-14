using API.ViewModels;
using System;
using TodoService.Identity;

namespace API.UI.Account
{
    public sealed class RegisterResponse
    {
        public RegisterResponse(string token, Guid accountId)
        {
            Token = token;
            AccountId = accountId;
        }

        public string Token { get; }

        public Guid AccountId { get; }
    }
}
