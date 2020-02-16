namespace TodoService.Domain
{
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
            await tableRepository.AddTask(task);
            return task;
        }

    }
}