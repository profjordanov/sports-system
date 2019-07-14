using System;

namespace Jbet.Domain.Views.Match
{
    public class MatchView
    {
        public Guid Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime Start { get; set; }
    }
}