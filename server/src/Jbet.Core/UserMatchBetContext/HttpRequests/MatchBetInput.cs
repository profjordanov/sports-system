using System;
using System.ComponentModel.DataAnnotations;

namespace Jbet.Core.UserMatchBetContext.HttpRequests
{
    public class MatchBetInput
    {
        [Required]
        public Guid MatchId { get; set; }
    }
}