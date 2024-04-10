using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Reset.SendEmail
{
    public class SendEmailResetCommand : IRequest
    { 
        public string UserEmailAddress { get; set; }
    }
}
