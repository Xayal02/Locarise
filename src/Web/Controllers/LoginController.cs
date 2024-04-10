using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.CQRS.Commands.UserCommands.Add;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.CQRS.Commands.UserCommands.Login;
using Application.CQRS.Commands.LoginCommands.Confirm.SendEmail;
using Application.CQRS.Commands.LoginCommands.Confirm.ConfirmUser;
using Application.CQRS.Commands.LoginCommands.Reset.SendEmail;
using Application.CQRS.Commands.LoginCommands.Reset.ResetPassword;
using Application.Common.Filters;
using Application.CQRS.Commands.LoginCommands.Delete.DeleteAllUsers;
using Application.CQRS.Commands.LoginCommands.Delete.DeleteByUsername;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {


        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public LoginController()
        {

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<AddUserCommandResponse>> CreateUser(AddUserCommand request)
        {
            var result = await Mediator.Send(request);
            return result;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommandResponse>> Login(LoginCommand request)
        {


            var result = await Mediator.Send(request);
            return result;


        }

        //[HttpGet("signin-google")]
        //public async Task<IActionResult> GoogleLogin()
        //{
        //    var response = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    if (response.Principal == null) return BadRequest();

        //    var name = response.Principal.FindFirstValue(ClaimTypes.Name);
        //    var givenName = response.Principal.FindFirstValue(ClaimTypes.GivenName);
        //    var email = response.Principal.FindFirstValue(ClaimTypes.Email);
        //    //Do something with the claims
        //    // var user = await UserService.FindOrCreate(new { name, givenName, email});

        //    return Ok();
        //}


        //[HttpPost("SendEmailConfirmation")]
        //[CheckAccess]
        //public async Task<IActionResult> SendEmailConfirmation(SendEmailCommand request)
        //{
        //    var result = await Mediator.Send(request);
        //    return Ok();
        //}

        [HttpPut("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmUserCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok();
        }

        [HttpPost("SendEmailReset")]
        public async Task<IActionResult> SendEmailReset(SendEmailResetCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok();
        }

        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok();
        }

        [HttpDelete("DeleteUserByUsername")]
        public async Task<IActionResult> DeleteUserByUsername (DeleteUserByUsernameCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok();
        }

        [HttpDelete("DeleteAllUsers")]
        public async Task<IActionResult> DeleteAllUsers()
        {
            var result = await Mediator.Send(new DeleteAllUsersCommand());
            return Ok();
        }

    }
}
