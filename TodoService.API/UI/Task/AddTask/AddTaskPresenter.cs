namespace API.UI.Task.AddTask
{
    using API.ViewModels;
    using App.Boundaries.TableTask.AddTask;
    using Microsoft.AspNetCore.Mvc;

    public class AddTaskPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Output(AddTaskOutput output)
        {
            var res = new AddTaskResponse(new TableTaskModel(
                output.TableTask.Id.ToGuid(),
                output.TableTask.Text.ToString(),
                (int)output.TableTask.State));

            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
