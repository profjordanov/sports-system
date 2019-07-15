using System;
using System.Threading.Tasks;
using Jbet.Domain.Entities;

namespace Jbet.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetByMatchAndUserAsync(Guid matchId, Guid userId);

        Task<Comment> AddAsync(string content, Guid matchId, Guid userId);
    }
}