namespace TodoService.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using Table = Entities.Table;
    using TableTask = Entities.TableTask;

    public sealed class TableRepository : ITableRepository
    {
        private readonly TodoServiceContext context;

        public TableRepository(TodoServiceContext context)
        {
            this.context = context;
        }

        public async Task AddTableAsync(ITable table)
        {
            await context.Tables.AddAsync((Table)table);
        }

        public async Task AddTaskAsync(ITableTask task)
        {
            await context.TableTasks.AddAsync((TableTask)task);
        }

        public async Task<ITable> GetTableAsync(BaseEntityId tableId, BaseEntityId accountId)
        {
            var table = await context.Tables
                .Where(x => x.Id.Equals(tableId) 
                       && x.AccountId.Equals(accountId)
                       && x.State != TableState.Deleted)
                .SingleOrDefaultAsync();

            if(table is null)
            {
                throw new Exception($"Not found table with id: {tableId}");
            }

            var tasks = await context.TableTasks
                .Where(x => x.TableId.Equals(tableId) 
                       && x.State != TaskState.Deleted)
                .ToListAsync();

            table.Load(tasks);

            return table;
        }

        public async Task<ITableTask> GetTaskAsync(BaseEntityId tableId, BaseEntityId accountId, BaseEntityId taskId)
        {
            var table = await context.Tables
                .Where(x => x.Id.Equals(tableId)
                       && x.AccountId.Equals(accountId)
                       && x.State != TableState.Deleted)
                .SingleOrDefaultAsync();

            if(table is null)
            {
                throw new Exception($"Not found table with id: {tableId}");
            }

            var task = await context.TableTasks
                .Where(x => x.Id.Equals(taskId)
                       && x.TableId.Equals(tableId)
                       && x.State != TaskState.Deleted)
                .SingleOrDefaultAsync();

            return task;
        }

        public async Task Update(ITable table)
        {
            await context.Tables.AddAsync((Table)table);
        }

        public async Task Update(ITableTask task)
        {
            await context.TableTasks.AddAsync((TableTask)task);
        }
    }
}
