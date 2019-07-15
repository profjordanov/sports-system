using System;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface IVotesRepository
    {
        Task<bool> HasAnyByTeamAndUserAsync(Guid teamId, Guid userId);
    }
}