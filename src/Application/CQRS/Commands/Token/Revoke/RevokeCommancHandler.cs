using Application.Common.Authorization;
using Domain.Common.Interfaces.Repository;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Entities.Login;

using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Token.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommand>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<User, int> _userRepository;
        public RevokeCommandHandler(IHttpContextAccessor httpContextAccessor, IRepository<User, int> userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RevokeCommand request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext == null) throw new BadRequestException();

            var currentClaims = TokenFactory.ReturnCurrentUserClaims(_httpContextAccessor.HttpContext);

            int id = Convert.ToInt32(currentClaims["Id"]);

            User user = await _userRepository.GetSingle(id);

            user.RefreshToken = null;

            await _userRepository.Update(user);
            await _userRepository.Commit(cancellationToken);

            return Unit.Value;


            
        }
    }
}
