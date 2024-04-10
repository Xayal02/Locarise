using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Confirm.SendEmail
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(u => u.UserEmailAddress)
                    .NotEmpty().WithMessage("Email address cannot be empty")
                    .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be in correct format");
        }
    }
}

