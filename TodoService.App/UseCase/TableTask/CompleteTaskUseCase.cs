using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCase.TableTask
{
    using App.Boundaries.TableTask.CompleteTask;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;

    public sealed class CompleteTaskUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;
        private readonly IUnitOfWork unitOfWork;


        public CompleteTaskUseCase(IOutputPort outputPort,
                                   ITableRepository tableRepository,
                                   IUnitOfWork unitOfWork)
        {
            this.outputPort = outputPort;
            this.unitOfWork = unitOfWork;
            this.tableRepository = tableRepository;
        }

        public async Task Handle(CompleteTaskInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var task = await tableRepository.GetTaskAsync(input.TableId, input.AccountId, input.TaskId);
                task.Complete();
                await unitOfWork.Save();

                BuildOutput(task);
            }
            catch (Exception e)
            {
                outputPort.WriteError(e.Message);
            }
        }

        private void BuildOutput(ITableTask task)
        {
            var res = new CompleteTaskOutput(task);
            outputPort.Output(res);
        }
    }
}
