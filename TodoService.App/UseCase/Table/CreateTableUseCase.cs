namespace App.UseCase.Table
{
    using App.Boundaries.Table.CreateTable;
    using System;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;

    public sealed class CreateTableUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly TableService tableService;
        private readonly IAccountRepository accountRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateTableUseCase(IOutputPort outputPort, 
            TableService tableService,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this.outputPort = outputPort;
            this.tableService = tableService;
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(CreateTableInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var account = await accountRepository.GetAccountAsync(input.AccountId);
                var table = await tableService.CreateTable(input.TableName, account);
                await unitOfWork.Save();

                BuildOutput(table);
            }
            catch(Exception e)
            {
                outputPort.WriteError(e.Message);
            }
        }

        private void BuildOutput(ITable table)
        {
            var output = new CreateTableOutput(table);
            outputPort.Output(output);
        }
    }
}
