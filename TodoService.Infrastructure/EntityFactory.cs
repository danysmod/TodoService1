namespace TodoService.Infrastructure
{
    using Domain;

    public sealed class EntityFactory : ITableFactory, IAccountFactory
    {
        public IAccount NewAccount() => new Entities.Account();

        public ITable NewTable(TableTitle tableName, IAccount account) => new Entities.Table(tableName, account);

        public ITableTask NewTask(ITable table, TaskText taskText) => new Entities.TableTask(table, taskText);
    }
}