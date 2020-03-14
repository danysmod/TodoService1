using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.ChangeTableTitle
{
    using API.ViewModels;
    using App.Boundaries.Table.ChangeTableTitle;
    using Microsoft.AspNetCore.Mvc;

    public class ChangeTableTitlePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(ChangeTableTitleOutput output)
        {
            var tableModel = new TableModel(
                output.Table.Name.ToString(),
                output.Table.Id.ToGuid());

            var res = new ChangeTableTitleResponse(tableModel);
            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
