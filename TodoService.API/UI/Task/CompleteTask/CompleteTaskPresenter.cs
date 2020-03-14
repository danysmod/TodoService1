using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Task.CompleteTask
{
    using API.ViewModels;
    using App.Boundaries.TableTask.CompleteTask;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CompleteTaskPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(CompleteTaskOutput output)
        {
            var res = new TableTaskModel(
                output.TableTask.Id.ToGuid(),
                output.TableTask.Text.ToString(),
                (int)output.TableTask.State);

            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
