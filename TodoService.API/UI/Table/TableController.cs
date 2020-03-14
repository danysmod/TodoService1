namespace API.UI.Table
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using API.UI.Table.ChangeTableTitle;
    using API.UI.Table.CreateTable;
    using API.UI.Table.DeleteTable;
    using API.UI.Table.GetTableDetails;
    using App.Boundaries.Table.ChangeTableTitle;
    using App.Boundaries.Table.CreateTable;
    using App.Boundaries.Table.DeleteTable;
    using App.Boundaries.Table.GetTableDetails;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TodoService.Domain;

    [Route("api/table/[action]")]
    [ApiController]
    [Authorize]
    public sealed class TableController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTableResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromServices] IMediator mediator,
            [FromServices] CreateTablePresenter presenter,
            [FromBody][Required] CreateTableRequest request)
        {
            var accountId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new CreateTableInput(
                new TableTitle(request.TableName), 
                new BaseEntityId(new Guid(accountId)));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeTableTitleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeTitle(
            [FromServices] IMediator mediator,
            [FromServices] ChangeTableTitlePresenter presenter,
            [FromBody][Required] ChangeTableTitleRequest request)
        {
            var accountId = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new ChangeTableTitleInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId),
                new TableTitle(request.Title));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteTableResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(
            [FromServices] IMediator mediator,
            [FromServices] DeleteTablePresenter presenter,
            [FromBody][Required] DeleteTableRequest request)
        {
            var accountId = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new DeleteTableInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTableDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetails(
            [FromServices] IMediator mediator,
            [FromServices] GetTableDetailsPresenter presenter,
            [FromBody][Required] GetTableDetailsRequest request)
        {
            var accountId = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;

            var input = new GetTableDetailsInput(
                new BaseEntityId(new Guid(accountId)),
                new BaseEntityId(request.TableId));

            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}
