using Application.CQRS.Commands.ContactUs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost("Contact")]
        public async Task<IActionResult> Contact([FromBody] ContactUsCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
