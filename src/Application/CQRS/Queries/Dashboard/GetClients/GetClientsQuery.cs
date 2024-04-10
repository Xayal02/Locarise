using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Dashboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Dashboard.GetClients
{
    public class GetClientsQuery : IRequest<List<ClientModel>>
    {
    }

    public class ClientModel : IMapFrom<Client>
    {
        public string IconPath { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Client, ClientModel>()
                   .ForMember(dest => dest.IconPath, opt => opt.MapFrom(src => src.IconPath.Replace("\\\\", "\\")));

    }
}
