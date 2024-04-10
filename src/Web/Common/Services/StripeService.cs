using Application.Common.Interfaces;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.Login;
using Domain.Entities.Payment;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Common.Services
{
    public class StripeService : IStripeService
    {
        private readonly TokenService _tokenService;
        private readonly CustomerService _customerService;
        private readonly ChargeService _chargeService;

        public StripeService(TokenService tokenService, CustomerService customerService, ChargeService chargeService)
        {

            _tokenService = tokenService;
            _customerService = customerService;
            _chargeService = chargeService;
        }

        public async Task<string> CreateCustomer(User user, Domain.Entities.Payment.Card card, CancellationToken cancellationToken)
        {
            var tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = card.HolderName,
                    Number = card.Number,
                    ExpYear = card.ExpiryYear,
                    ExpMonth = card.ExpiryMonth,
                    Cvc = card.Cvc
                }
            };

            //var token = await _tokenService.CreateAsync(tokenOptions, null, cancellationToken);

            var customerOptions = new CustomerCreateOptions
            {
                Email = user.Email,
                Name = user.FullName,
                Source = "tok_visa"
            };

            var customer = await _customerService.CreateAsync(customerOptions, null, cancellationToken);

            return customer.Id;

        }

        public async Task<string> CreateCharge(User user, string customerId, string currency, int amount, string description, CancellationToken cancellationToken)
        {
            var chargeOptions = new ChargeCreateOptions
            {
                Currency = currency,
                Amount = amount,
                ReceiptEmail = user.Email,
                Customer = customerId,
                Description = description
                
            };

            var charge = await _chargeService.CreateAsync(chargeOptions, null, cancellationToken);

            return charge.Id;
        }

       
    }
}
