using Application.Common.Authorization;
using Application.CQRS.Commands.LoginCommands.Confirm.SendEmail;
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


namespace Application.CQRS.Commands.LoginCommands.Reset.SendEmail
{
    public class SendEmailResetCommandHandler : IRequestHandler<SendEmailResetCommand>
    {
        private readonly IRepository<User, int> _userRepository;
        const string subject = "Password Reset";
        const string bodyMessage = "Hi, to reset your password click here :  locarise.ca/reset";

        public SendEmailResetCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(SendEmailResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingle(user => user.Email.ToLower() == request.UserEmailAddress.ToLower());

            if (user is null) throw new NotFoundException();

            string userToken = TokenFactory.GenerateJwtTokenForSendingEmail(user);

            StringBuilder stringBuilder = new StringBuilder(bodyMessage);
            stringBuilder.Append("/" + userToken);

            await Task.Run(() => EmailSender.SendEmailTo(request.UserEmailAddress, subject, stringBuilder.ToString()));

            return Unit.Value;
        }
    }
}
