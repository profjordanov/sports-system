using System.Collections.Generic;
using Jbet.Domain.Entities;

namespace Jbet.Domain.Repositories
{
    public interface IMatchRepository
    {
        IAsyncEnumerable<Match> TopTreeMatchesByBetsAsync();
    }
}