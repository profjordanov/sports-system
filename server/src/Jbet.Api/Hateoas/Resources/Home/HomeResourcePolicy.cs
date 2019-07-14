using System;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Home
{
    public class HomeResourcePolicy : IPolicy<HomeResource>
    {
        public Action<LinksPolicyBuilder<HomeResource>> PolicyConfiguration => policy =>
        {
            policy.RequireSelfLink();
        };
    }
}