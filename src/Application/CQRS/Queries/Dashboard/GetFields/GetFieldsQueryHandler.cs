using Application.CQRS.Queries.Dashboard.GetComments;
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

namespace Application.CQRS.Queries.Dashboard.GetFields
{
    public class GetFieldsQueryHandler : IRequestHandler<GetFieldsQuery, List<FieldDto>>
    {
        private readonly IRepository<Field, int> _fieldRepository;
        private readonly IMapper _mapper;

        public GetFieldsQueryHandler(IRepository<Field, int> fieldRepository, IMapper mapper)
        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
        }
        public async Task<List<FieldDto>> Handle(GetFieldsQuery request, CancellationToken cancellationToken)
        {
            var fields = _fieldRepository.GetAll().Where(c => !(c.IsDeleted)).ProjectTo<FieldDto>(_mapper.ConfigurationProvider).ToList();
            return fields;
        }
    }
}
