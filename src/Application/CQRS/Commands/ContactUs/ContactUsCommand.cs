using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.ContactUs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.ContactUs
{
    public class ContactUsCommand : IRequest<ContactUsCommandResponse>, IMapTo<Contact>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        void Mapping(Profile profile) => profile.CreateMap<ContactUsCommand, Contact>()
                                                .ForMember(dest => dest.RequesterFullName, opt => opt.MapFrom(src => src.FullName))
                                                .ForMember(dest => dest.RequesterEmail, opt => opt.MapFrom(src => src.Email))
                                                .ForMember(dest => dest.RequesterPhone, opt => opt.MapFrom(src => src.Phone));


    }

    public class ContactUsCommandResponse
    {
        public bool Success { get; set; }
    }
}
