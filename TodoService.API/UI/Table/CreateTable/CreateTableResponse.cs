namespace API.UI.Table.CreateTable
{
    using System;
    
    public sealed class CreateTableResponse
    {
        public CreateTableResponse(
            string tableName,
            Guid tableId)
        {
            TableName = tableName;
            TableId = tableId;
        }

        public string TableName { get; }
        
        public Guid TableId { get; }
    }
}
