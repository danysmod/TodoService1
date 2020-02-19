namespace API.UI.Table.CreateTable
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using App.Boundaries.Table.CreateTable;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TodoService.Domain;

    [Route("api/table/[controller]")]
    [ApiController]
    [Authorize]
    public class CreateTableController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTableResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromServices] IMediator mediator,
            [FromServices] CreateTablePresenter presenter,
            [FromForm][Required] CreateTableRequest request)
        {
            var input = new CreateTableInput(new TableName(request.TableName));
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpGet]
        public IActionResult GetABC(int n)
        {
            var b = n * n;
            return Content(b.ToString());
        }
    }
}
