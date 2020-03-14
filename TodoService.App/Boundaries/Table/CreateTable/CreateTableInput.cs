namespace App.Boundaries.Table.CreateTable
{
    using TodoService.Domain;
    public sealed class CreateTableInput
    {
        public CreateTableInput(TableTitle tableName, BaseEntityId accountId)
        {
            TableName = tableName;
            AccountId = accountId;
        }

        public TableTitle TableName { get; }

        public BaseEntityId AccountId { get; }
    }
}
