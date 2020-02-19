namespace App.UseCase.Table
{
    using App.Boundaries.Table.AddTask;
    using System.Threading.Tasks;
    using TodoService.Domain;

    public class AddTaskUseCase : IUseCase
    {
        private readonly TableService tableService;
        private readonly IOutputPort outputPort;
        private readonly ITableRepository tableRepository;

        public AddTaskUseCase(TableService tableService, 
                              IOutputPort outputPort, 
                              ITableRepository tableRepository)
        {
            this.outputPort = outputPort;
            this.tableService = tableService;
            this.tableRepository = tableRepository;
        }

        public async Task Execute(AddTaskInput input)
        {
            var table = await tableRepository.GetTable(input.TableId);
            var task = await tableService.AddTask(table, input.TaskText);
            BuildOutput(table, task);
        }

        private void BuildOutput(ITable table, ITableTask task)
        {
            //var output = new CreateTableOutput(table);
            //outputPort.Output(output);
        }
    }
}
