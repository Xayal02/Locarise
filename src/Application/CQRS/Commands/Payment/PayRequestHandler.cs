using Application.Common.Interfaces;
using Domain.Common.Interfaces.Repository;
using Domain.Entities.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Payment
{
    public class PayRequestHandler : IRequestHandler<PayRequest>
    {
        private readonly IStripeService _stripeService;
        private readonly IRepository<User, int> _userRepository;
        private readonly ICurrentUserService _currentUserService;


        public PayRequestHandler(IStripeService stripeService, IRepository<User, int> userRepository, ICurrentUserService currentUserService)
        {
            _stripeService = stripeService;
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(PayRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingle(u => u.Id ==_currentUserService.UserId);
            string CreatedCustomerId = await _stripeService.CreateCustomer(user,request.CardInfo, cancellationToken);

            string CreatedChargeId = await _stripeService.CreateCharge(user,CreatedCustomerId, request.Currency, request.Amount, request.Description, cancellationToken);

            return Unit.Value;
        }
    }
}
