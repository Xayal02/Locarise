
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.AboutUs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.AboutUs.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientModel>>
    {

        private readonly IRepository<Client, int> _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IRepository<Client, int> clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;

        }
        public async Task<List<ClientModel>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {

            var clients = _clientRepository.GetAll().ProjectTo<ClientModel>(_mapper.ConfigurationProvider).ToList();

            return clients;

        }
    }
}
