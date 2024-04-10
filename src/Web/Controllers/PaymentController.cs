using Application.Common.Filters;
using Application.CQRS.Commands.Payment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [CheckAccess]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromBody] PayRequest request)
        {
            await Mediator.Send(request);

            return Ok();
        }
    }
}
