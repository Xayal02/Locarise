using Domain.Common.Interfaces.Repository;
using Domain.Entities.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Delete.DeleteAllUsers
{
    public class DeleteAllUsersCommandHandler : IRequestHandler<DeleteAllUsersCommand>
    {
        private readonly IRepository<User, int> _userRepository;

        public DeleteAllUsersCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteWhere(u => u.Id > 0);
            await _userRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
