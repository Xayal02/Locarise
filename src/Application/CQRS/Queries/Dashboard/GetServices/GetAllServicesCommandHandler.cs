using Application.CQRS.Commands.UserCommands.Add;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Application.CQRS.Queries.Dashboard.GetServices
{
    public class GetAllServicesCommandHandler : IRequestHandler<GetAllServicesCommand, List<ServiceModel>>
    {
        private readonly IRepository<Service, int> _serviceRepository;
        private readonly IMapper _mapper;

        public GetAllServicesCommandHandler(IRepository<Service, int> serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;

        }
        public async Task<List<ServiceModel>> Handle(GetAllServicesCommand request, CancellationToken cancellationToken)
        {

            var services =  _serviceRepository.GetAll().Where(s => !(s.IsDeleted)).ProjectTo<ServiceModel>(_mapper.ConfigurationProvider).ToList();

            return services;

        }
    }
}
