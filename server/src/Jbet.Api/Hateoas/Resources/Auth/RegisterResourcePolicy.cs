using System;
using Jbet.Api.Controllers;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Auth
{
    public class RegisterResourcePolicy : IPolicy<RegisterResource>
    {
        public Action<LinksPolicyBuilder<RegisterResource>> PolicyConfiguration => policy =>
        {
            policy.RequireSelfLink();
            policy.RequireRoutedLink(LinkNames.Auth.Login, nameof(AuthController.Login));
        };
    }
}