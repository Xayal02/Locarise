using Application.Common.Authorization;
using Domain.Common.Interfaces.Repository;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Login;

namespace Application.CQRS.Commands.LoginCommands.Confirm.ConfirmUser
{
    public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand>
    {
        private readonly IRepository<User, int> _userRepository;

        public ConfirmUserCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {
            var claims = TokenFactory.TokenReader(request.Token);

            var userEmail = claims["Email"];

            if (string.IsNullOrEmpty(userEmail)) throw new ApiException("Invalid URL");
            
            var user = await _userRepository.GetSingle(u => u.Email.ToLower() == userEmail.ToLower());

            if (user == null) throw new NotFoundException();

            user.EmailConfirmed = true;

            await _userRepository.Update(user);

            await _userRepository.Commit(cancellationToken);

            return Unit.Value;


        }
    }
}
