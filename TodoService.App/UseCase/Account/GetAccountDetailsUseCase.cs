using App.Boundaries.Account.GetAccountDetails;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Domain;
using TodoService.Identity;

namespace App.UseCase.Account
{
    public class GetAccountDetailsUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly IAccountRepository accountRepository;
        private readonly UserManager<ApplicationUser> userManager;asdfasdf

        public GetAccountDetailsUseCase(IOutputPort outputPort,
                                        IAccountRepository accountRepository,
                                        UserManager<ApplicationUser> userManager)
        {
            this.outputPort = outputPort;
            this.accountRepository = accountRepository;
            this.userManager = userManager;
        }
        public async Task Handle(GetAccountDetailsInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var appUser = await userManager.Users
                    .FirstOrDefaultAsync(x => x.AccountId.Equals(input.AccountId));

                var account = await accountRepository.GetAccountAsync(input.AccountId);
                BuildOutput(account,appUser);
            }
            catch
            {

            }
        }

        private void BuildOutput(IAccount account, ApplicationUser user)
        {
            var output = new GetAccountDetailsOutput(account, user);
            outputPort.Output(output);
        }
    }
}
