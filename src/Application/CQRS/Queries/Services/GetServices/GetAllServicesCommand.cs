using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Application.CQRS.Queries.Services.GetServices
{
    public class GetAllServicesCommand : IRequest<List<ServiceModel>>
    {

    }

    public class ServiceModel : IMapFrom<Service>
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string IconPath { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Service, ServiceModel>()
            .ForMember(dest => dest.IconPath, opt => opt.MapFrom(src => src.IconPath.Replace("\\\\", "\\")));

    }
}
