using Domain.Entities.Payment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Payment
{
    public  class PayRequest : IRequest
    {
        public Card CardInfo { get; set; }
        public string Currency { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

    }
}
