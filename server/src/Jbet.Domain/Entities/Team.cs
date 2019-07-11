using Jbet.Domain._Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbet.Domain.Entities
{
    public class Team : IAggregate
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public DateTime Founded { get; set; }

        public string Website { get; set; }

        // References

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Match> AwayMatches { get; set; }

        public virtual ICollection<Match> HomeMatches { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}