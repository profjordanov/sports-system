using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Jbet.Domain.Entities;
using MediatR;
using Optional;

namespace Jbet.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Option<User>> GetAsync(Guid id);

        Task<Option<User>> GetByEmailAsync(string email);

        Task<Unit> ReplaceClaimAsync(User account, string claimType, string claimValue);

        Task<Option<Unit, Error>> RegisterAsync(User user, string password);

        Task<bool> CheckPasswordAsync(User user, string password);

        Task<IList<Claim>> GetClaimsAsync(User user);
    }
}