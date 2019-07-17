using Jbet.Api.Controllers;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

namespace Jbet.Api.Hateoas.Resources.Home
{
    public class ApiRootResourcePolicy : IPolicy<ApiRootResource>
    {
        public Action<LinksPolicyBuilder<ApiRootResource>> PolicyConfiguration => policy =>
        {
            policy.RequireRoutedLink(LinkNames.Auth.Login, nameof(AuthController.Login), null, cond => cond.Assert(x => !x.IsUserLoggedIn));
            policy.RequireRoutedLink(LinkNames.Auth.Register, nameof(AuthController.Register), null, cond => cond.Assert(x => !x.IsUserLoggedIn));
            policy.RequireRoutedLink(LinkNames.Auth.Logout, nameof(AuthController.Logout), null, cond => cond.AuthorizeRoute());
        };
    }
}