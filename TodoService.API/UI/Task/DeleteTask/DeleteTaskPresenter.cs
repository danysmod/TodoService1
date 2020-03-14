using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.DeleteTask
{
    using App.Boundaries.TableTask.DeleteTask;
    using Microsoft.AspNetCore.Mvc;

    public sealed class DeleteTaskPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(DeleteTaskOutput output)
        {
            var res = new DeleteTaskResponse(output.TaskId.ToGuid());
            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
