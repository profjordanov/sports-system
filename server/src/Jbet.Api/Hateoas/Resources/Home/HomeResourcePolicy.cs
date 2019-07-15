using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

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