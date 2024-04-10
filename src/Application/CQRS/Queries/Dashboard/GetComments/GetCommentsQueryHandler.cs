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

namespace Application.CQRS.Queries.Dashboard.GetComments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<CommentDto>>
    {
        private readonly IRepository<Comment, int> _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(IRepository<Comment, int> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async  Task<List<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = _commentRepository.GetAll().Where(c => !(c.IsDeleted)).ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToList();
            return comments;
        }
    }
}
