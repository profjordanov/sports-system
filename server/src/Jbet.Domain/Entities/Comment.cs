using System;
using System.ComponentModel.DataAnnotations;
using Jbet.Domain._Base;

namespace Jbet.Domain.Entities
{
    public class Comment : IAggregate
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        // References

        public Guid MatchId { get; set; }

        public virtual Match Match { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
