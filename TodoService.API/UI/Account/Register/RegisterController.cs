
namespace API.UI.Account.Register
{
    using App.Boundaries.Account.Register;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [Route("/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(
            [FromServices] IMediator mediator,
            [FromServices] RegisterPresenter presenter,
            [FromForm][Required] RegisterRequest request)
        {
            var input = new RegisterInput(request.Email, request.Password);
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}
