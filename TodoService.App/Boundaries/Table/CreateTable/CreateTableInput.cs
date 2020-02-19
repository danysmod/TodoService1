namespace App.Boundaries.Table.CreateTable
{
    using TodoService.Domain;
    public sealed class CreateTableInput
    {
        public CreateTableInput(TableName tableName)
        {
            TableName = tableName;
        }

        public TableName TableName { get; }
    }
}
