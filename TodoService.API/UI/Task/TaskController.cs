using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.UI.Task.AddTask;
using API.UI.Task.ChangeTaskTitle;
using API.UI.Task.CompleteTask;
using API.UI.Task.DeleteTask;
using App.Boundaries.TableTask.AddTask;
using App.Boundaries.TableTask.ChangeTitleTask;
using App.Boundaries.TableTask.CompleteTask;
using App.Boundaries.TableTask.DeleteTask;
using FluentMediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoService.Domain;

namespace API.UI.Task
{
    [Route("api/task/[action]")]
    [ApiController]
    [Authorize]
    public class TaskController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddTaskResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTask(
            [FromServices] IMediator mediator,
            [FromServices] AddTaskPresenter presenter,
            [FromBody][Required] AddTaskRequest request)
        {
            var accountId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new AddTaskInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId),
                new TaskText(request.Title));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeTaskTitleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeTitle(
            [FromServices] IMediator mediator,
            [FromServices] ChangeTaskTitlePresenter presenter,
            [FromBody][Required] ChangeTaskTitleRequest request)
        {
            var accountId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new ChangeTitleTaskInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId),
                new BaseEntityId(request.TaskId),
                new TaskText(request.Title));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompleteTaskResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Complete(
            [FromServices] IMediator mediator,
            [FromServices] CompleteTaskPresenter presenter,
            [FromBody][Required] CompleteTaskRequest request)
        {
            var accountId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new CompleteTaskInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId),
                new BaseEntityId(request.TaskId));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteTaskResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(
            [FromServices] IMediator mediator,
            [FromServices] DeleteTaskPresenter presenter,
            [FromBody][Required] DeleteTaskRequest request)
        {
            var accountId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new DeleteTaskInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId),
                new BaseEntityId(request.TaskId));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}