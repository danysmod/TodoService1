namespace TodoService.Infrastructure
{
    using System;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using Table = TodoService.Infrastructure.Entities.Table;
    using TableTask = TodoService.Infrastructure.Entities.TableTask;

    public class TableRepository : ITableRepository
    {
        private readonly TodoServiceContext context;

        public TableRepository(TodoServiceContext context)
        {
            this.context = context;
        }

        public async Task AddTable(ITable table)
        {
            await context.Tables.AddAsync((Table)table);
            await context.SaveChangesAsync();
        }

        public async Task AddTask(ITableTask task)
        {
            await context.TableTasks.AddAsync((TableTask)task);
            await context.SaveChangesAsync();
        }

        public async Task<ITable> GetTable(BaseEntityId entityId)
        {
            throw new NotImplementedException();
        }
    }
}
