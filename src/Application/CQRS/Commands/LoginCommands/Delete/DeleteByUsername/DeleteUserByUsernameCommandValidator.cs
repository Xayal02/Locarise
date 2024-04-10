using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Delete.DeleteByUsername
{
    public class DeleteUserByUsernameCommandValidator : AbstractValidator<DeleteUserByUsernameCommand>
    {
        public DeleteUserByUsernameCommandValidator()
        {
            RuleFor(u => u.EmailAddress).NotEmpty().WithMessage("Email address cannot be empty");
        }
    }
}
