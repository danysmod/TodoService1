namespace TodoService.Domain
{
    public interface ITableFactory
    {
        ITable NewTable(TableTitle tableName, IAccount account);

        ITableTask NewTask(ITable table, TaskText taskText);
    }
}