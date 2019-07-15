using Jbet.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface IVotesRepository
    {
        Task<bool> HasAnyByTeamAndUserAsync(Guid teamId, Guid userId);
        Task<Vote> AddAsync(Guid teamId, Guid userId, CancellationToken cancellationToken);
    }
}