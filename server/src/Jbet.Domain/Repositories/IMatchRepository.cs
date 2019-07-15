using Jbet.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface IMatchRepository
    {
        IAsyncEnumerable<Match> TopTreeMatchesByBetsAsync();

        Task<List<Match>> GetPagedListAsync(
            CancellationToken cancellationToken,
            int page = 0,
            int pageSize = 20);
    }
}