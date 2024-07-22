using Application.Common.Mappings;
using Domain.Entities.HomePage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.HomePage.GetFields
{
    public class GetFieldsQuery : IRequest<List<FieldDto>>
    {
    }

    public class FieldDto : IMapFrom<Field>
    {
        public string Name { get; set; }
    }
}
