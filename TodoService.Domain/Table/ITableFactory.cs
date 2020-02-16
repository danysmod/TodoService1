namespace TodoService.Domain
{
    public interface ITableFactory
    {
        ITable NewTable(TableName tableName);

        ITableTask NewTask(ITable table, TaskText taskText);
    }
}