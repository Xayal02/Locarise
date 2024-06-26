﻿using Application.CQRS.Commands.LoginCommands.Confirm.SendEmail;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Reset.SendEmail
{
    public class SendEmailResetCommandValidator : AbstractValidator<SendEmailResetCommand>
    {
        public SendEmailResetCommandValidator()
        {
            RuleFor(u => u.UserEmailAddress)
                    .NotEmpty().WithMessage("Email address cannot be empty")
                    .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be in correct format");
        }

    }
}
