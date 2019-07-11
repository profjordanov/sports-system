using System;
using Jbet.Domain._Base;

namespace Jbet.Domain.Entities
{
    public class Player : IAggregate
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public double Height { get; set; }

        // References

        public Guid? TeamId { get; set; }

        public virtual Team Team { get; set; }

    }
}