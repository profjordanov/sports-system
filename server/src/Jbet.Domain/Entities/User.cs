using Jbet.Domain._Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Jbet.Domain.Entities
{
    public class User : IdentityUser<Guid>, IAggregate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        // References

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserMatchBet> UserMatchBets { get; set; }

        public virtual ICollection<Vote> UserTeamVotes { get; set; }

    }
}