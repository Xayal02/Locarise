using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Dashboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Dashboard.GetComments
{
    public class GetCommentsQuery :IRequest<List<CommentDto>>
    {

    }

    public class CommentDto : IMapFrom<Comment>
    {
        public string Text { get; set; }
        public string UserFullName { get; set; }
        public short Value { get; set; }

        public void Mapping(Profile profile) =>
        profile.CreateMap<Comment, CommentDto>();
    }
}
