using Jbet.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface IBetsRepository
    {
        Task<UserMatchBet> AddHomeBetAsync(
            Guid userId,
            Guid matchId,
            decimal homeBet);

        Task<UserMatchBet> AddAwayBetAsync(
            Guid userId,
            Guid matchId,
            decimal awayBet);

        Task<UserMatchBet> AddAsync(
            Guid userId,
            Guid matchId,
            decimal homeBet,
            decimal awayBet);

        decimal SumAwayBetsByMatchId(Guid matchId);

        decimal SumHomeBetsByMatchId(Guid matchId);
    }
}