using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCase.Table
{
    using App.Boundaries.Table.DeleteTable;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;

    public sealed class DeleteTableUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteTableUseCase(IOutputPort outputPort,
                                  ITableRepository tableRepository,
                                  IUnitOfWork unitOfWork)
        {
            this.outputPort = outputPort;
            this.tableRepository = tableRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTableInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var table = await tableRepository.GetTableAsync(input.TableId, input.AccountId);
                
                foreach(var a in table.GetTasks())
                {
                    a.Delete();
                }
                table.Delete();

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
            var res = new DeleteTableOutput(table);
            outputPort.Output(res);
        }
    }
}
