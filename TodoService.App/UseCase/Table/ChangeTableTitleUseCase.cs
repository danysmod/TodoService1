using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCase.Table
{
    using App.Boundaries.Table.ChangeTableTitle;
    using System.Linq;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Domain.Services;

    public class ChangeTableTitleUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChangeTableTitleUseCase(IOutputPort outputPort,
                                       ITableRepository tableRepository,
                                       IUnitOfWork unitOfWork)
        {
            this.outputPort = outputPort;
            this.tableRepository = tableRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangeTableTitleInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var table = await tableRepository.GetTableAsync(input.TableId, input.AccountId);
                table.ChangeName(input.Title);
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
            var res = new ChangeTableTitleOutput(table);
            outputPort.Output(res);
        }
    }
}
