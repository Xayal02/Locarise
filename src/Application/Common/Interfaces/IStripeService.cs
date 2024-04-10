using Domain.Entities.Login;
using Domain.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IStripeService
    {
        public  Task<string> CreateCustomer(User user, Card card, CancellationToken cancellationToken);
        public  Task<string> CreateCharge(User user, string customerId, string currency,int amount,string description, CancellationToken cancellationToken);
    }
}
