
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.HomePage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.HomePage.GetFAQs
{
    public class GetFAQsQueryHandler : IRequestHandler<GetFAQsQuery, List<FAQDto>>
    {
        private readonly IRepository<FAQ, int> _faqRepository;
        private readonly IMapper _mapper;

        public GetFAQsQueryHandler(IRepository<FAQ, int> faqRepository, IMapper mapper)
        {
            _faqRepository = faqRepository;
            _mapper = mapper;
        }
        public async Task<List<FAQDto>> Handle(GetFAQsQuery request, CancellationToken cancellationToken)
        {
            var faqs = _faqRepository.GetAll().Where(c => !c.IsDeleted).ProjectTo<FAQDto>(_mapper.ConfigurationProvider).ToList();
            return faqs;
        }
    }


}
