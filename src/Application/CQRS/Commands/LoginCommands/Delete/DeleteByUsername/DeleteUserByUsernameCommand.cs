using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Delete.DeleteByUsername
{
    public class DeleteUserByUsernameCommand : IRequest
    {
        public string EmailAddress { get; set; }
    }
}
