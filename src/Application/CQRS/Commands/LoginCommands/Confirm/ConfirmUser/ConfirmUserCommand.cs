using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Confirm.ConfirmUser
{
    public class ConfirmUserCommand : IRequest
    {
        public string Token { get; set; }
    }
}
