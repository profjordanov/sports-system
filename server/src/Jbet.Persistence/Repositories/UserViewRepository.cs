using System;
using System.Threading.Tasks;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views;
using Optional;

namespace Jbet.Persistence.Repositories
{
    public class UserViewRepository : IUserViewRepository
    {
        public Task<Option<UserView>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}