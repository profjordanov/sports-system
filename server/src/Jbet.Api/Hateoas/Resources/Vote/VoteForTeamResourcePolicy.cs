using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

namespace Jbet.Api.Hateoas.Resources.Vote
{
    public class VoteForTeamResourcePolicy : IPolicy<VoteForTeamResource>
    {
        public Action<LinksPolicyBuilder<VoteForTeamResource>> PolicyConfiguration => policy =>
            {
                policy.RequireSelfLink();
            };
    }
}