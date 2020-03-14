using TodoService.Domain;

namespace App.Boundaries.Account.GetAccountDetails
{
    public sealed class GetAccountDetailsInput
    {
        public GetAccountDetailsInput(BaseEntityId accountId)
        {
            AccountId = accountId;
        }

        public BaseEntityId AccountId { get; set; }
    }
}
