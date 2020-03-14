using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.GetTableDetails
{
    using API.ViewModels;
    using App.Boundaries.Table.GetTableDetails;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetTableDetailsPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Output(GetTableDetailsOutput output)
        {
            var tasks = new List<TableTaskModel>();
            foreach(var task in output.Table.GetTasks())
            {
                tasks.Add(new TableTaskModel(
                    task.Id.ToGuid(),
                    task.Text.ToString(),
                    (int)task.State));
            }

            var tableDetails = new TableDetailsModel(
                output.Table.Name.ToString(),
                output.Table.Id.ToGuid(),
                (int)output.Table.State,
                tasks);

            var res = new GetTableDetailsResponse(tableDetails);
            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
