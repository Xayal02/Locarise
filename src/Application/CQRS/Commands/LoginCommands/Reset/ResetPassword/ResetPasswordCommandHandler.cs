using Application.Common.Authorization;
using Application.CQRS.Commands.LoginCommands.Reset.SendEmail;
using Application.Helpers;
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


namespace Application.CQRS.Commands.LoginCommands.Reset.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IRepository<User, int> _userRepository;

        public ResetPasswordCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var claims = TokenFactory.TokenReader(request.Token);

            var userEmail = claims["Email"];

            if (string.IsNullOrEmpty(userEmail)) throw new ApiException("Invalid URL");

            var user = await _userRepository.GetSingle(user => user.Email.ToLower() ==  userEmail.ToLower());

            if (user == null) throw new NotFoundException();

            var Password = TextHasher.EncryptText(request.Password);
            user.Password = Password;

            await _userRepository.Update(user);
            await _userRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
