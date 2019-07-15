using System;
using Jbet.Api.Hateoas.Resources.Base;
using RiskFirst.Hateoas;

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