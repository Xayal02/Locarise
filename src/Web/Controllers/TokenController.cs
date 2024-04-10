using Application.Common.Filters;
using Application.CQRS.Commands.Token.Refresh;
using Application.CQRS.Commands.Token.Revoke;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("Revoke")]
        [CheckAccess]
        public async Task<IActionResult> Revoke()
        {
            var result = await Mediator.Send(new RevokeCommand());
            return Ok();
        }
    }
}
