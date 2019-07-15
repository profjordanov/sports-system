using System;
using System.Collections.Generic;
using Jbet.Api.Hateoas.Resources.Base;
using Jbet.Domain.Views.Comment;

namespace Jbet.Api.Hateoas.Resources.Match
{
    public class MatchDetailsResource : Resource
    {
        public Guid Id { get; set; }

        public Guid HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public Guid AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime Start { get; set; }

        public decimal AwayBets { get; set; }

        public decimal HomeBets { get; set; }

        public IEnumerable<CommentView> Comments { get; set; }
    }
}