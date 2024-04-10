
using Application.CQRS.Queries.Dashboard.GetClients;
using Application.CQRS.Queries.Dashboard.GetComments;
using Application.CQRS.Queries.Dashboard.GetFAQs;
using Application.CQRS.Queries.Dashboard.GetFields;
using Application.CQRS.Queries.Dashboard.GetServices;
using Application.CQRS.Queries.Dashboard.GetStatistics;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private  IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        [HttpGet("GetServices")]

        public async Task<IActionResult> GetServices()
        {
            var result = await Mediator.Send(new GetAllServicesCommand());
            return Ok(result);
        }

        [HttpGet("GetComments")]
        public async Task<IActionResult> GetComments()
        {
            var result = await Mediator.Send(new GetCommentsQuery());

            return Ok(result);
        }

        [HttpGet("GetFAQs")]
        public async Task<IActionResult> GetFAQs()
        {
            var result = await Mediator.Send(new GetFAQsQuery());

            return Ok(result);
        }

        [HttpGet("GetFields")]
        public async Task<IActionResult> GetFields()
        {
            var result = await Mediator.Send(new GetFieldsQuery());

            return Ok(result);
        }

        [HttpGet("GetClients")]
        public async Task<IActionResult> GetClients()
        {
            var result = await Mediator.Send(new GetClientsQuery());

            return Ok(result);
        }

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await Mediator.Send(new GetStatisticsQuery());

            return Ok(result);
        }

    }
}
