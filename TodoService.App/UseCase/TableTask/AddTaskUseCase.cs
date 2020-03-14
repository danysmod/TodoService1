namespace App.UseCase.TableTask
{
    using System;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;
    using App.Boundaries.TableTask.AddTask;

    public sealed class AddTaskUseCase : IUseCase
    {
        private readonly TableService tableService;
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddTaskUseCase(TableService tableService, 
                              IOutputPort outputPort, 
                              ITableRepository tableRepository,
                              IAccountRepository accountRepository,
                              IUnitOfWork unitOfWork)
        {
            this.outputPort = outputPort;
            this.tableService = tableService;
            this.tableRepository = tableRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(AddTaskInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;            
            }

            try
            {
                
                var table = await tableRepository.GetTableAsync(input.TableId, input.AccountId);
                var task = await tableService.AddTask(table, input.TaskText);
                await unitOfWork.Save();
                BuildOutput(task);
            }
            catch(Exception e)
            {
                outputPort.WriteError(e.Message);
            }
        }

        private void BuildOutput(ITableTask task)
        {
            var output = new AddTaskOutput(task);
            outputPort.Output(output);
        }
    }
}
