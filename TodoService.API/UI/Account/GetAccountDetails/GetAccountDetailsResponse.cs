using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Account.GetAccountDetails
{
    public sealed class GetAccountDetailsResponse
    {
        public GetAccountDetailsResponse(AccountDetailsModel accountDetails)
        {
            AccountDetails = accountDetails;
        }

        public AccountDetailsModel AccountDetails { get; }
    }
}
