using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

namespace Jbet.Api.Hateoas.Resources.Match
{
    public class MatchResourcePolicy : IPolicy<MatchResource>
    {
        public Action<LinksPolicyBuilder<MatchResource>> PolicyConfiguration => policy =>
        {
            policy.RequireSelfLink();
        };
    }
}