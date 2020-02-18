using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.CreateTable
{
    using App.Boundaries.Table.CreateTable;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CreateTablePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Output(CreateTableOutput output)
        {
            var createTableResponse = new CreateTableResponse(
                output.Table.Name.ToString(),
                output.Table.Id.ToGuid());

            ViewModel = new OkObjectResult(createTableResponse);
        }
    }
}
