using Jbet.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetByMatchAndUserAsync(Guid matchId, Guid userId);

        Task<Comment> AddAsync(string content, Guid matchId, Guid userId);
    }
}