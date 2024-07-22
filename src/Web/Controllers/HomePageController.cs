
using Application.CQRS.Commands.TemporarilyCommands;
using Application.CQRS.Queries.HomePage.GetFAQs;
using Application.CQRS.Queries.HomePage.GetFields;
using Application.CQRS.Queries.HomePage.GetStatistics;
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
    public class HomePageController : ControllerBase
    {
        private  IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

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

        

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await Mediator.Send(new GetStatisticsQuery());

            return Ok(result);
        }

        //[HttpGet("TemporarilyUpdateServiceForImages")]
        //public async Task<IActionResult> TemporarilyUpdateServiceForImages()
        //{
        //    var result = await Mediator.Send(new UpdateServiceForImagesCommand());

        //    return Ok(result);
        //}

    }
}
