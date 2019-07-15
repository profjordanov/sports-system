using Jbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface IMatchRepository
    {
        Task<Match> GetByIdAsync(Guid id);

        IAsyncEnumerable<Match> TopTreeMatchesByBetsAsync();

        Task<List<Match>> GetPagedListAsync(
            CancellationToken cancellationToken,
            int page = 0,
            int pageSize = 20);
    }
}