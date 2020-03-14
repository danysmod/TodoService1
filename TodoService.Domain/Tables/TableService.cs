namespace TodoService.Domain
{
    using System.Linq;
    using System.Threading.Tasks;

    public class TableService
    {
        private readonly ITableFactory tableFactory;
        private readonly ITableRepository tableRepository;

        public TableService(ITableFactory factory,
                            ITableRepository repository)
        {
            tableFactory = factory;
            tableRepository = repository;
        }

        public async Task<ITableTask> AddTask(ITable table, TaskText taskText)
        {
            var task = tableFactory.NewTask(table, taskText);
            await tableRepository.AddTaskAsync(task);
            return task;
        }

        public async Task<ITable> CreateTable(TableTitle name, IAccount account)
        {
            var table = tableFactory.NewTable(name, account);
            await tableRepository.AddTableAsync(table);

            return table;
        }

        public async Task DeleteTable(ITable table)
        {
            var deletedTable = table.Delete();
            deletedTable.GetTasks().Select(async x => await tableRepository.Update(x));
            await tableRepository.Update(deletedTable);
        }
    }
}