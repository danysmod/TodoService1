namespace API.UI.Account.Register
{
    using App.Boundaries.Account.Register;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TodoService.Identity;

    public class RegisterPresenter : IOutputPort
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public RegisterPresenter(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult ViewModel { get; private set; }
        public void Output(RegisterOutput output)
        {
            signInManager.SignInAsync(output.User, false);

            var res = new RegisterResponse(output.User);
            ViewModel = new OkObjectResult(res);
        }
    }
}
