using Application.CQRS.Queries.AboutUs.GetClients;
using Application.CQRS.Queries.AboutUs.GetComments;
using Application.CQRS.Queries.AboutUs.GetTeamMembers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutUsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("GetClients")]
        public async Task<IActionResult> GetClients()
        {
            var result = await Mediator.Send(new GetClientsQuery());

            return Ok(result);
        }

        [HttpGet("GetTeamMembers")]
        public async Task<IActionResult> GetTeamMembers()
        {
            var result = await Mediator.Send(new GetTeamMembersRequest());
            return Ok(result);
        }

        [HttpGet("GetComments")]
        public async Task<IActionResult> GetComments()
        {
            var result = await Mediator.Send(new GetCommentsQuery());
            return Ok(result);
        }
    }
}
