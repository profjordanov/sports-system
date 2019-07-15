using Jbet.Domain.Views.Comment;
using System;
using System.Collections.Generic;

namespace Jbet.Domain.Views.Match
{
    public class MatchDetailsView
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