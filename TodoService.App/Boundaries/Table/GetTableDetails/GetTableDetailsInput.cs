using System;
using System.Collections.Generic;
using System.Text;
using TodoService.Domain;

namespace App.Boundaries.Table.GetTableDetails
{
    public sealed class GetTableDetailsInput
    {
        public GetTableDetailsInput(BaseEntityId accountId, BaseEntityId tableId)
        {
            AccountId = accountId;
            TableId = tableId;
        }

        public BaseEntityId AccountId { get; }

        public BaseEntityId TableId { get; }
    }
}
