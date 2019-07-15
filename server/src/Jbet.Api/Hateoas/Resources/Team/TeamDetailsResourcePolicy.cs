using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

namespace Jbet.Api.Hateoas.Resources.Team
{
    public class TeamDetailsResourcePolicy : IPolicy<TeamDetailsResource>
    {
        public Action<LinksPolicyBuilder<TeamDetailsResource>> PolicyConfiguration => policy =>
            {
                policy.RequireSelfLink();
            };
    }
}