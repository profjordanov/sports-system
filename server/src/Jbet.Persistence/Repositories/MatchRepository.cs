using System;
using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Persistence.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MatchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Match> GetByIdAsync(Guid id) =>
            _dbContext
                .Matches
                .FirstOrDefaultAsync(match => match.Id == id);

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

        public Task<List<Match>> GetPagedListAsync(
            CancellationToken cancellationToken,
            int page = 0,
            int pageSize = 20) =>
            _dbContext
                .Matches
                .Include(match => match.UserMatchBets)
                .Include(match => match.HomeTeam)
                .Include(match => match.AwayTeam)
                .OrderBy(match => match.Start)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
    }
}