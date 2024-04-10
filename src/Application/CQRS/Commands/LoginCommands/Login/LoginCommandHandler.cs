using Application.Helpers;
using Domain.Common.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Entities.Login;

using Application.Common.Authorization;

namespace Application.CQRS.Commands.UserCommands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IRepository<User, int> _userRepository;

        public LoginCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new LoginCommandResponse();

            User user = await _userRepository.GetSingleIncluding(user => user.Email.ToLower() == request.UserName.ToLower() && user.EmailConfirmed == true, user => user.Role);
            
            if (user is not null)
            {
                var successfulLogin = TextHasher.Verify(request.Password, user.Password);

                if (successfulLogin)
                {
                    string accessToken = TokenFactory.GenerateJwtAccessToken(user);
                    string refreshToken = TokenFactory.GenerateRefreshToken();

                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(3);

                    await _userRepository.Update(user);
                    await _userRepository.Commit(cancellationToken);

                    response.AccessToken = accessToken;
                    response.RefrehToken = refreshToken;

                    return response;
                }
            }


            throw new NotFoundException("Incorrect login or password");
        }
    }
}
