using System;

namespace Jbet.Domain.Views.Team
{
    public class TeamView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public int Votes { get; set; }
    }
}