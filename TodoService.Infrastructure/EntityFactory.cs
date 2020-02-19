namespace TodoService.Infrastructure
{
    using Domain;

    public class EntityFactory : ITableFactory, IAccountFactory
    {
        public IAccount NewAccount() => new Entities.Account();

        public ITable NewTable(TableName tableName) => new Entities.Table(tableName);

        public ITableTask NewTask(ITable table, TaskText taskText) => new Entities.TableTask(table, taskText);
    }
}