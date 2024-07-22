using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.AboutUs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.AboutUs.GetClients
{
    public class GetClientsQuery : IRequest<List<ClientModel>>
    {
    }

    public class ClientModel : IMapFrom<Client>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Client, ClientModel>();

    }
}
