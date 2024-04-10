using Application.Common.Authorization;
using Domain.Common.Interfaces.Repository;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Domain.Entities.Login;


namespace Application.CQRS.Commands.Token.Refresh
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
    {
        private readonly IRepository<User, int> _userRepository;

        public RefreshTokenCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetSingle( u => u.RefreshToken == request.RefreshToken);

            if (user == null || string.IsNullOrEmpty(user.RefreshToken) || user.RefreshTokenExpiryTime < DateTime.UtcNow) throw new BadRequestException();

            string newAccessToken = TokenFactory.GenerateJwtAccessToken(user);
            string newRefreshToken = TokenFactory.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userRepository.Update(user);
            await _userRepository.Commit(cancellationToken);

            return new RefreshTokenCommandResponse() { NewAccessToken = newAccessToken, NewRefreshToken = newRefreshToken };
        }
    }
}
