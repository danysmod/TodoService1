namespace App.Boundaries.Table.CreateTable
{
    using TodoService.Domain;
    public sealed class CreateTableOutput
    {
        public CreateTableOutput(ITable table)
        {
            Table = (Table)table;
        }

        public Table Table { get; }
    }
}
