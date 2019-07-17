using Jbet.Domain.Views;
using Optional;
using System;
using System.Threading.Tasks;

namespace Jbet.Domain.Repositories
{
    public interface IUserViewRepository
    {
        Task<Option<UserView>> GetAsync(Guid id);
    }
}