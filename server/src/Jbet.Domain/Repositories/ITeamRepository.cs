using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jbet.Domain.Entities;

namespace Jbet.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> BestTreeTeamsByVoteAsync(CancellationToken cancellationToken);
    }
}