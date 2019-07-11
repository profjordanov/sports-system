using System;
using System.Threading.Tasks;
using Jbet.Domain.Views;
using Optional;

namespace Jbet.Domain.Repositories
{
    public interface IUserViewRepository
    {
        Task<Option<UserView>> GetAsync(Guid id);
    }
}