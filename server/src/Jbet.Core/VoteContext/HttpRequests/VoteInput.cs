using System;
using System.ComponentModel.DataAnnotations;

namespace Jbet.Core.VoteContext.HttpRequests
{
    public class VoteInput
    {
        [Required]
        public Guid TeamId { get; set; }
    }
}