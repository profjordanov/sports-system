using System.ComponentModel.DataAnnotations;

namespace Jbet.Core.UserMatchBetContext.HttpRequests
{
    public class MatchHomeBetInput : MatchBetInput
    {
        [Required]
        [Range(3, 1000000)]
        public decimal HomeBet { get; set; }
    }
}