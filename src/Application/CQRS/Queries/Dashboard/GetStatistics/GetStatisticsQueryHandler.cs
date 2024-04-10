using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.Dashboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Dashboard.GetStatistics
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, List<StatisticsModel>>
    {
        private readonly IRepository<Statistics, int> _statisticsRepository;
        private readonly IMapper _mapper;

        public GetStatisticsQueryHandler(IRepository<Statistics, int> statisticsRepository, IMapper mapper)
        {
            _statisticsRepository = statisticsRepository;
            _mapper = mapper;
        }
        public async Task<List<StatisticsModel>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics =  _statisticsRepository.GetAll().ProjectTo<StatisticsModel>(_mapper.ConfigurationProvider).ToList();
            return statistics;
        }
    }
}
