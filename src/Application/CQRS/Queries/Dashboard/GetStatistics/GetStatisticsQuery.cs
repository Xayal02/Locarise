using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Dashboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Dashboard.GetStatistics
{
    public class GetStatisticsQuery : IRequest<List<StatisticsModel>> { }
    
    public class StatisticsModel : IMapFrom<Statistics>
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Statistics,StatisticsModel>();
    }
}
