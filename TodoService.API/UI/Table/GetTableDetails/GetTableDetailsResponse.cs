using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.GetTableDetails
{
    public sealed class GetTableDetailsResponse
    {
        public GetTableDetailsResponse(TableDetailsModel tableDetails)
        {
            TableDetails = tableDetails;
        }

        public TableDetailsModel TableDetails { get; }
    }
}
