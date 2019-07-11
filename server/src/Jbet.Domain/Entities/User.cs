using System;
using System.Collections.Generic;
using Jbet.Domain._Base;
using Microsoft.AspNetCore.Identity;

namespace Jbet.Domain.Entities
{
    public class User : IdentityUser<Guid>, IAggregate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        // References

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserMatchBet> UserMatchesBets { get; set; }
    }
}