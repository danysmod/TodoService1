using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.DeleteTable
{
    using App.Boundaries.Table.DeleteTable;
    using Microsoft.AspNetCore.Mvc;

    public sealed class DeleteTablePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Output(DeleteTableOutput output)
        {
            var res = new DeleteTableResponse(output.TableId.ToGuid());
            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
