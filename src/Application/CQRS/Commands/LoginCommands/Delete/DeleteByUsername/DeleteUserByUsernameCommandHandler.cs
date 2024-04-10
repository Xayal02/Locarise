using Domain.Common.Interfaces.Repository;
using Domain.Entities.Login;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Delete.DeleteByUsername
{
    public class DeleteUserByUsernameCommandHandler : IRequestHandler<DeleteUserByUsernameCommand>
    {
        private readonly IRepository<User, int> _userRepository;

        public DeleteUserByUsernameCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserByUsernameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirst(u => u.Email.ToLower() == request.EmailAddress.ToLower());

            if (user == null) throw new NotFoundException();

            await _userRepository.Delete(user);
            await _userRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
