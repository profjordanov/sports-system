using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Jbet.Persistence.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MatchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncEnumerable<Match> TopTreeMatchesByBetsAsync() =>
             _dbContext
                .Matches
                .Include(match => match.UserMatchBets)
                .Include(match => match.HomeTeam)
                .Include(match => match.AwayTeam)
                .OrderByDescending(match =>
                    match.UserMatchBets.Sum(bet => bet.AwayBet) + match.UserMatchBets.Sum(bet => bet.HomeBet))
                .Take(3)
                .ToAsyncEnumerable();
    }
}