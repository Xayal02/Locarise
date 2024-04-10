using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.UserCommands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string UserName { get; set; } 
        public string Password { get; set; }
    }

    public class LoginCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefrehToken { get; set; }
    }
}
