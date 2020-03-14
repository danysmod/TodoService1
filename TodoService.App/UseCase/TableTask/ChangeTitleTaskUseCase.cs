using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCase.TableTask
{
    using App.Boundaries.TableTask.ChangeTitleTask;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;

    public class ChangeTitleTaskUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChangeTitleTaskUseCase(IOutputPort outputPort,
                                      ITableRepository tableRepository,
                                      IUnitOfWork unitOfWork)
        {
            this.outputPort = outputPort;
            this.tableRepository = tableRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangeTitleTaskInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var task = await tableRepository.GetTaskAsync(input.TableId, input.AccountId, input.TaskId);
                task.ChangeTitle(input.Title);
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
            var res = new ChangeTitleTaskOutput(task);
            outputPort.Output(res);
        }
    }
}
