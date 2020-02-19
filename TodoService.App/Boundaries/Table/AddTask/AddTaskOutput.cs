namespace App.Boundaries.Table.AddTask
{
    using TodoService.Domain;
    public sealed class AddTaskOutput
    {
        public AddTaskOutput(ITable table, ITableTask task)
        {
            Table = (Table)table;
            //Table.
        }

        public Table Table { get; }
    }
}
