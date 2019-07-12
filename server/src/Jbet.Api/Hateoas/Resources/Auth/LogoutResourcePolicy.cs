using System;
using Jbet.Api.Controllers;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Auth
{
    public class LogoutResourcePolicy : IPolicy<LogoutResource>
    {
        public Action<LinksPolicyBuilder<LogoutResource>> PolicyConfiguration => policy =>
        {
            policy.RequireRoutedLink(LinkNames.Auth.Login, nameof(AuthController.Login));
            policy.RequireRoutedLink(LinkNames.Auth.Register, nameof(AuthController.Register));
        };
    }
}