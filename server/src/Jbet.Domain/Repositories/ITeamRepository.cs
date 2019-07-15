using Jbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetByIdAsync(Guid id);

        Task<IEnumerable<Team>> BestTreeTeamsByVoteAsync(CancellationToken cancellationToken);
    }
}