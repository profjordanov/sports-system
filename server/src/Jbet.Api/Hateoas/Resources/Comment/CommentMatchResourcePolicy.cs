using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;
using System;

namespace Jbet.Api.Hateoas.Resources.Comment
{
    public class CommentMatchResourcePolicy : IPolicy<CommentMatchResource>
    {
        public Action<LinksPolicyBuilder<CommentMatchResource>> PolicyConfiguration => policy =>
        {
            policy.RequireSelfLink();
        };
    }
}