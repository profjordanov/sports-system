using System;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

namespace Jbet.Api.Hateoas.Resources.Match
{
    public class MatchDetailsResourcePolicy : IPolicy<MatchDetailsResource>
    {
        public Action<LinksPolicyBuilder<MatchDetailsResource>> PolicyConfiguration => policy =>
            {
                policy.RequireSelfLink();
            };
    }
}