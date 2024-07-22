using Application.CQRS.Queries.AboutUs.GetComments;
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

namespace Application.CQRS.Queries.AboutUs.GetTeamMembers
{
    public class GetTeamMembersRequestHandler : IRequestHandler<GetTeamMembersRequest, List<TeamMemberDto>>
    {
        private readonly IRepository<TeamMember, int> _teamMembertRepository;
        private readonly IMapper _mapper;

        public GetTeamMembersRequestHandler(IRepository<TeamMember, int> teamMembertRepository, IMapper mapper)
        {
            _teamMembertRepository = teamMembertRepository;
            _mapper = mapper;
        }
        public  async Task<List<TeamMemberDto>> Handle(GetTeamMembersRequest request, CancellationToken cancellationToken)
        {
            var teamMembers = _teamMembertRepository.GetAll().Where(c => !c.IsDeleted).ProjectTo<TeamMemberDto>(_mapper.ConfigurationProvider).ToList();
            return teamMembers;
        }
    }
}
