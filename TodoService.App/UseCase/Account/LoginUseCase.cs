using App.Boundaries.Account.Login;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TodoService.Domain;
using TodoService.Domain.Services.Security;
using TodoService.Identity;

namespace App.UseCase.Account
{
    public class LoginUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenFactory<ApplicationUser> tokenFactory;
        private readonly IAccountRepository accountRepository;

        public LoginUseCase(IOutputPort outputPort,
                            ITokenFactory<ApplicationUser> tokenFactory,
                            UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IAccountRepository accountRepository)
        {
            this.outputPort = outputPort;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenFactory = tokenFactory;
            this.accountRepository = accountRepository;
        }

        public async Task Handle(LoginInput input)
        {
            if (input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            var res = await signInManager.PasswordSignInAsync(
                input.UserName, 
                input.Password, 
                false, 
                false);

            if(res.Succeeded)
            {
                var appUser = await userManager.FindByNameAsync(input.UserName);
                var token = tokenFactory.GenerateToken(appUser);
                BuildOutput(token, appUser);
            }
            else
            {
                outputPort.WriteError("Not found");
            }
        }

        private void BuildOutput(string Token, ApplicationUser applicationUser)
        {
            var output = new LoginOutput(Token, applicationUser);
            outputPort.Output(output);
        }
    }
}
