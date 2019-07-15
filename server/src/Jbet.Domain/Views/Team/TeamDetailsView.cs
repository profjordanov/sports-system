using Jbet.Domain.Views.Player;
using System;
using System.Collections.Generic;

namespace Jbet.Domain.Views.Team
{
    public class TeamDetailsView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public DateTime Founded { get; set; }

        public string Website { get; set; }

        public IEnumerable<PlayerView> Players { get; set; }

        public int Votes { get; set; }

        public bool UserHasVoted { get; set; }
    }
}