using AutoMapper;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.ContactUs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.ContactUs
{
    public class ContactUsCommandHandler : IRequestHandler<ContactUsCommand, ContactUsCommandResponse>
    {
        private readonly IRepository<Contact,int> _contactRepository;
        private readonly IMapper _mapper;

        public ContactUsCommandHandler(IRepository<Contact, int> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<ContactUsCommandResponse> Handle(ContactUsCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact>(request);

            await _contactRepository.Add(contact);
            await _contactRepository.Commit(cancellationToken);

            return new ContactUsCommandResponse() { Success = true };
        }
    }
}
