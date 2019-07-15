using Jbet.Domain.Entities;
using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Persistence.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Team> GetByIdAsync(Guid id) =>
            _dbContext
                .Teams
                .Include(team => team.Players)
                .Include(team => team.Votes)
                .FirstOrDefaultAsync(team => team.Id == id);

        public async Task<IEnumerable<Team>> BestTreeTeamsByVoteAsync(CancellationToken cancellationToken) =>
            await _dbContext
                .Teams
                .AsNoTracking()
                .Include(team => team.Votes)
                .OrderByDescending(team => team.Votes.Count)
                .Take(3)
                .ToListAsync(cancellationToken);
    }
}