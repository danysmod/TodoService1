namespace App.UseCase.Table
{
    using App.Boundaries.Table.CreateTable;
    using System.Threading.Tasks;
    using TodoService.Domain;

    public class CreateTableUseCase : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly TableService tableService;

        public CreateTableUseCase(IOutputPort outputPort, TableService tableService)
        {
            this.outputPort = outputPort;
            this.tableService = tableService;
        }


        public async Task Execute(CreateTableInput input)
        {
            var table = await tableService.CreateTable(input.TableName);
            BuildOutput(table);
            
        }

        private void BuildOutput(ITable table)
        {
            var output = new CreateTableOutput(table);
            outputPort.Output(output);
        }
    }
}
