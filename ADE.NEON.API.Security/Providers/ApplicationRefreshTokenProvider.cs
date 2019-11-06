using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.API.Security.Providers
{
    public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
    {
        private readonly double _expire;

        public ApplicationRefreshTokenProvider(double expire)
        {
            _expire = expire;
        }

        public override void Create(AuthenticationTokenCreateContext context)
        {
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(_expire - 1));
            context.SetToken(context.SerializeTicket());
        }

        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}
