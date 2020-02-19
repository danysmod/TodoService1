namespace App.UseCase.Account
{
    using App.Boundaries.Account;
    using App.Boundaries.Account.Register;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Identity;

    public sealed class RegisterUseCase : IUseCase
    {
        private readonly AccountService accountService;
        private readonly IOutputPort outputPort;
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterUseCase(IOutputPort outputPort, 
                               AccountService accountService,
                               UserManager<ApplicationUser> userManager)
        {
            this.outputPort = outputPort;
            this.accountService = accountService;
            this.userManager = userManager;
        }

        public async Task Execute(RegisterInput input)
        {
            var account = await accountService.CreateAccountAsync();

            var appUser = new ApplicationUser()
            {
                Email = input.Email,
                UserName = input.Email,
                AccountId = ((Account)account).Id
            };

            var res = await userManager.CreateAsync(appUser, input.Password);

            if(res.Succeeded)
            {
                BuildOutput(appUser);
            }
        }

        private void BuildOutput(ApplicationUser appUser)
        {
            var output = new RegisterOutput(appUser);
            outputPort.Output(output);
        }
    }
}
