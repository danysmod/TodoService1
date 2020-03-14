using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCase.Table
{
    using App.Boundaries.Table.GetTableDetails;
    using System.Threading.Tasks;
    using TodoService.Domain;

    public sealed class GetTableDetailsUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;

        public GetTableDetailsUseCase(IOutputPort outputPort,
                                      ITableRepository tableRepository)
        {
            this.outputPort = outputPort;
            this.tableRepository = tableRepository;
        }

        public async Task Handle(GetTableDetailsInput input)
        {
            if(input is null)
            {
                outputPort.WriteError(Message.InputIsNull);
                return;
            }

            try
            {
                var table = await tableRepository.GetTableAsync(input.TableId, input.AccountId);

                BuildOutput(table);
            }
            catch (Exception e)
            {
                outputPort.WriteError(e.Message);
            }
        }

        private void BuildOutput(ITable table)
        {
            var res = new GetTableDetailsOutput(table);
            outputPort.Output(res);
        }
    }
}
