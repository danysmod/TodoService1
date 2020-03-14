namespace API.UI.Account
{
    using API.ViewModels;
    using App.Boundaries.Account.Login;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class LoginPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(LoginOutput output)
        {
            var res = new LoginResponse(output.Token, output.AccountId);
            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
