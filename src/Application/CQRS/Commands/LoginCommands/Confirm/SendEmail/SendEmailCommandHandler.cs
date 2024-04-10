using Application.Common.Authorization;
using Application.Helpers;
using Domain.Common.Interfaces.Repository;
using Domain.Entities;
using Domain.Entities.Login;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.LoginCommands.Confirm.SendEmail
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly IRepository<User, int> _userRepository;
        const string subject = "Account Confirmation";
        const string bodyMessage = "Hi, to confirm your account click here : https://testurl.com/";

        public SendEmailCommandHandler(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
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
