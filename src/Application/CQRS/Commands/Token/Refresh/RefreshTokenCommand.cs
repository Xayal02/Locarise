using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Token.Refresh
{
    public class RefreshTokenCommand : IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenCommandResponse
    {
        public string NewAccessToken { get; set; }
        public string NewRefreshToken { get; set; }
    }
}
