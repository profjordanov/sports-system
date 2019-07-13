using Jbet.Domain.Repositories;
using Jbet.Persistence.EntityFramework;

namespace Jbet.Persistence.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;

    }
}