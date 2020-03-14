
namespace API.UI.Account
{
    using API.UI.Account.GetAccountDetails;
    using App.Boundaries.Account.GetAccountDetails;
    using App.Boundaries.Account.Login;
    using App.Boundaries.Account.Register;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using TodoService.Domain;
    using TodoService.Identity;

    [ApiController]
    [Authorize]
    [Route("/api/[action]")]
    public sealed class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(
            [FromServices] IMediator mediator,
            [FromServices] LoginPresenter presenter,
            [FromBody][Required] LoginRequest request)
        {
            var input = new RegisterInput(request.Username, request.Password);
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(
            [FromServices] IMediator mediator,
            [FromServices] LoginPresenter presenter,
            [FromBody][Required] LoginRequest request)
        {
            var input = new LoginInput(request.Username, request.Password);
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountDetails(
            [FromServices] IMediator mediator,
            [FromServices] GetAccountDetailsPresenter presenter)
        {
            var accountId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value;
            var input = new GetAccountDetailsInput(new BaseEntityId(new Guid(accountId)));
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }

        [HttpGet]
        public async Task<IActionResult> Logout(
            [FromServices] SignInManager<ApplicationUser> signInManager)
        {
            await signInManager.SignOutAsync();
            return new OkResult();
        }
    }
}
