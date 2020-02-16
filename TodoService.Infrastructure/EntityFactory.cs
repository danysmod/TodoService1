namespace TodoService.Infrastructure
{
    using Domain;

    public class EntityFactory : ITableFactory
    {
        public ITable NewTable(TableName tableName) => new Entities.Table(tableName);

        public ITableTask NewTask(ITable table, TaskText taskText) => new Entities.TableTask(table, taskText);
    }
}