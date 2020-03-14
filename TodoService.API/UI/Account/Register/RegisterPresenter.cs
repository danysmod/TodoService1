namespace API.UI.Account
{
    using API.ViewModels;
    using App.Boundaries.Account.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public sealed class RegisterPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(RegisterOutput output)
        {
            var res = new RegisterResponse(output.Token, output.Account.Id.ToGuid());
            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
