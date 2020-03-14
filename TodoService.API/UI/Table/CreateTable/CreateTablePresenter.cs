using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.CreateTable
{
    using API.ViewModels;
    using App.Boundaries.Table.CreateTable;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CreateTablePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Output(CreateTableOutput output)
        {
            var tasks = new List<TableTaskModel>();
            foreach(var item in output.Table.GetTasks())
            {
                tasks.Add(new TableTaskModel(item.Id.ToGuid(), item.Text.ToString(), (int)item.State));
            }

            var table = new TableDetailsModel(
                output.Table.Name.ToString(),
                output.Table.Id.ToGuid(),
                (int)output.Table.State,
                tasks);

            var res = new CreateTableResponse(table);

            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
