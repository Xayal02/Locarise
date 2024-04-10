using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.UserCommands.Add
{
    public class AddUserCommand : IRequest<AddUserCommandResponse>,IMapTo<User>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<AddUserCommand, User>();
    }
    public class AddUserCommandResponse
    {
        public bool EmailSended { get; set; }
    }
}
