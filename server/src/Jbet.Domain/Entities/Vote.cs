using System;
using System.ComponentModel.DataAnnotations;
using Jbet.Domain._Base;

namespace Jbet.Domain.Entities
{
    public class Vote : IAggregate
    {
        [Key]
        public Guid Id { get; set; }

        [Range(1,10)]
        public int Value { get; set; }

        // References

        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}