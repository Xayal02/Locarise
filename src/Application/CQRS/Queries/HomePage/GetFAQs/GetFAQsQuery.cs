using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.HomePage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.HomePage.GetFAQs
{
    public class GetFAQsQuery : IRequest<List<FAQDto>>
    {
    }

    public class FAQDto : IMapFrom<FAQ>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<FAQ, FAQDto>();
    }
}
