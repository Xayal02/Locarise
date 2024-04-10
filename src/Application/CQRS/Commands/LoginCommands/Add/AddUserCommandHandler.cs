using Application.Helpers;
using AutoMapper;
using Domain.Common.Interfaces.Repository;
using Domain.Entities;
using Domain.Entities.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Application.Common.Authorization;
using System.Xml.Linq;

namespace Application.CQRS.Commands.UserCommands.Add
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommandResponse>
    {
        private readonly IRepository<User,int> _usersRepository;
        private readonly IMapper _mapper;
        const string subject = "Account Confirmation";
        const string bodyMessage = "Hi, to confirm your account click here : locarise.ca/activate";

        public AddUserCommandHandler(IRepository<User, int> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<AddUserCommandResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _usersRepository.Any(u => u.Email == request.Email);

            if(isExist) throw new AlreadyExistException(request.Email);

            var newUser = _mapper.Map<User>(request);

            newUser.Password = TextHasher.EncryptText(request.Password);

            await _usersRepository.Add(newUser);

            await _usersRepository.Commit(cancellationToken);

            if (newUser.Id > 0)
            {
                string userToken = TokenFactory.GenerateJwtTokenForSendingEmail(newUser);

                StringBuilder stringBuilder = new StringBuilder(bodyMessage);
                stringBuilder.Append("/" + userToken);

                await Task.Run(() => EmailSender.SendEmailTo(newUser.Email, subject, stringBuilder.ToString()));

                return new AddUserCommandResponse() { EmailSended = true };
            }


            return new AddUserCommandResponse() { EmailSended = false};
        }
    }
}
