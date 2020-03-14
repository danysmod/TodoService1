using API.ViewModels;
using App.Boundaries.Account.GetAccountDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Account.GetAccountDetails
{
    public class GetAccountDetailsPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(GetAccountDetailsOutput output)
        {
            var tables = new List<TableModel>();
            foreach(var table in output.Account.Tables.GetTables())
            {
                tables.Add(new TableModel(
                    table.Name.ToString(),
                    table.Id.ToGuid()));
            }

            var accountDetails = new AccountDetailsModel(output.Username, tables);

            var result = new GetAccountDetailsResponse(accountDetails);
            ViewModel = new OkObjectResult(result);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
