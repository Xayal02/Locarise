using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.AboutUs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.AboutUs.GetTeamMembers
{
    public class GetTeamMembersRequest : IRequest<List<TeamMemberDto>>
    {
    }

    public class TeamMemberDto : IMapFrom<TeamMember>
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ImagePath { get; set; }

        void Mapping(Profile profile) => profile.CreateMap<TeamMember, TeamMemberDto>();
    }
}
