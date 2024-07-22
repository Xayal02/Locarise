using Application.CQRS.Queries.Services.GetServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private  IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("GetServices")]
        public async Task<ActionResult> GetServices()
        {
            var result = await Mediator.Send(new GetAllServicesCommand());
            return Ok(result);
        }


    }
}
