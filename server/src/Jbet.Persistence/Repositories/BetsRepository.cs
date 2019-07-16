using System;
using System.Threading.Tasks;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;

namespace Jbet.Persistence.Repositories
{
    public class BetsRepository : IBetsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BetsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UserMatchBet> AddHomeBetAsync(
            Guid userId,
            Guid matchId,
            decimal homeBet) =>
            AddAsync(userId, matchId, homeBet, 0);

        public Task<UserMatchBet> AddAwayBetAsync(
            Guid userId,
            Guid matchId,
            decimal awayBet) =>
            AddAsync(userId, matchId, 0, awayBet);

        public async Task<UserMatchBet> AddAsync(
            Guid userId,
            Guid matchId,
            decimal homeBet,
            decimal awayBet)
        {
            var entity = new UserMatchBet
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                MatchId = matchId,
                AwayBet = awayBet,
                HomeBet = homeBet
            };

            await _dbContext.UserMatchBets.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}