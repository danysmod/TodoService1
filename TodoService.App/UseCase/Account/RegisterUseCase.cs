namespace App.UseCase.Account
{
    using App.Boundaries.Account.Register;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;
    using TodoService.Domain.Services.Security;
    using TodoService.Identity;

    public sealed class RegisterUseCase : IUseCase
    {
        private readonly AccountService accountService;
        private readonly IOutputPort outputPort;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITokenFactory<ApplicationUser> tokenGenerator;

        public RegisterUseCase(IOutputPort outputPort, 
                               AccountService accountService,
                               UserManager<ApplicationUser> userManager,
                               SignInManager<ApplicationUser> signInManager,
                               IUnitOfWork unitOfWork,
                               ITokenFactory<ApplicationUser> tokenGenerator)
        {
            this.outputPort = outputPort;
            this.accountService = accountService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task Handle(RegisterInput input)
         {
            if (input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            var account = await accountService.CreateAccountAsync();
            var appUser = new ApplicationUser()
            {
                Email = input.Email,
                UserName = input.Email,
                AccountId = ((Account)account).Id,
            };
            var res = await userManager.CreateAsync(appUser, input.Password);

            if (res.Succeeded)
            {
                await unitOfWork.Save();
                await signInManager.SignInAsync(appUser, false);
                var token = tokenGenerator.GenerateToken(appUser);
                BuildOutput(token, account, appUser);
            }
            else
            {
                var message = res.Errors.Select(x => x.Description).Aggregate((a,b) => a+"\n"+b.ToString());
                outputPort.WriteError(message);
            }
        }   

        private void BuildOutput(string token, IAccount account, ApplicationUser applicationUser)
        {
            var output = new RegisterOutput(token, account, applicationUser);
            outputPort.Output(output);
        }
    }
}
