namespace Jbet.Domain.Events.UserMatchBets
{
    public class UserMadeAwayBet : UserMadeMatchBet
    {
        public decimal AwayBet { get; set; }
    }
}