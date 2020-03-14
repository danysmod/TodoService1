
namespace App.Boundaries.Table.ChangeTableTitle
{
    using TodoService.Domain;
    
    public sealed class ChangeTableTitleInput
    {
        public ChangeTableTitleInput(BaseEntityId accountId, BaseEntityId tableId, TableTitle title)
        {
            AccountId = accountId;
            TableId = tableId;
            Title = title;
        }

        public BaseEntityId AccountId { get; }

        public BaseEntityId TableId { get; }

        public TableTitle Title { get; }
    }
}
