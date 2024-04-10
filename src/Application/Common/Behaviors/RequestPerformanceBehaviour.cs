using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ICurrentUserService _currentUserService;

        public RequestPerformanceBehaviour(
            ICurrentUserService currentUserService)
        {
            _timer = new Stopwatch();
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 1000)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService.UserId;

                //_logger.LogWarning("Long Running Request detected: {Name} ({ElapsedMilliseconds} milliseconds), UserId: {@UserId}, Request: {@Request}",
                //    requestName, elapsedMilliseconds, userId, request);
            }

            return response;
        }
    }

}
