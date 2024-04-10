using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.UserCommands.Login
{
    public  class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.UserName)
                .NotEmpty().WithMessage("Username field cannot be empty")
                .NotNull().WithMessage("Username field cannot be empty");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password field cannot be empty")
                .NotNull().WithMessage("Password field cannot be empty");
        }
    }
}
