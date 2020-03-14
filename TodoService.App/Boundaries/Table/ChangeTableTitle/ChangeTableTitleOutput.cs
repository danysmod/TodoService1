namespace App.Boundaries.Table.ChangeTableTitle
{
    using TodoService.Domain;

    public sealed class ChangeTableTitleOutput
    {
        public ChangeTableTitleOutput(ITable table)
        {
            Table = (Table)table;
        }

        public Table Table { get; }
    }
}
