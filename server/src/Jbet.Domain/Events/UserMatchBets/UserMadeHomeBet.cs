namespace Jbet.Domain.Events.UserMatchBets
{
    public class UserMadeHomeBet : UserMadeMatchBet
    {
        public decimal HomeBet { get; set; }
    }
}