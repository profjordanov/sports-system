using System.ComponentModel.DataAnnotations;

namespace Jbet.Core.UserMatchBetContext.HttpRequests
{
    public class MatchAwayBetInput : MatchBetInput
    {
        [Required]
        [Range(3, 1000000)]
        public decimal AwayBet { get; set; }
    }
}