using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Reset.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
