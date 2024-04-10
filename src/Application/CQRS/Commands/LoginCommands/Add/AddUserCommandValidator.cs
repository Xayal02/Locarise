using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.UserCommands.Add
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name cannot be empty")
                .MinimumLength(5).WithMessage("Name must be greater than 5");

            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Password cannot be empty");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address cannot be empty")
                .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be in correct format");
        }
    }
}
