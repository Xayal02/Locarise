using Domain.Common.Interfaces.Repository;
using Domain.Entities.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.TemporarilyCommands
{
    public class UpdateServiceForImagesCommandHandler : IRequestHandler<UpdateServiceForImagesCommand>
    {
        private readonly IRepository<Service, int> _serviceRepository;

        public UpdateServiceForImagesCommandHandler(IRepository<Service, int> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<Unit> Handle(UpdateServiceForImagesCommand request, CancellationToken cancellationToken)
        {
            var services = _serviceRepository.GetAll().Where(x => !x.IsDeleted).ToList();

            foreach (Service service in services)
            {
                var oldPath = service.IconPath.Substring(service.IconPath.IndexOf("Images")).Replace("\\\\","/");

                string newPath = "http://khayal02-001-site1.jtempurl.com/" + oldPath;

                service.IconPath = newPath;

                await _serviceRepository.Update(service);

                await _serviceRepository.Commit(cancellationToken);


            }

            return Unit.Value;
        }
    }
}
