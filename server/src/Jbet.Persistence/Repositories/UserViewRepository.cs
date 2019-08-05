using AutoMapper;
using Jbet.Core.AuthContext;
using Jbet.Domain.Repositories;
using Jbet.Domain.Views;
using Jbet.Persistence.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbet.Persistence.Repositories
{
    public class UserViewRepository : IUserViewRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserViewRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Option<UserView>> GetAsync(Guid id)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == id);

            var userClaims = await _dbContext
                .UserClaims
                .Where(uc => uc.UserId == id)
                .ToListAsync();

            return user
                .SomeNotNull()
                .Map(usr => MapRoleIds(_mapper.Map<UserView>(usr), userClaims));
        }

        private static UserView MapRoleIds(UserView user, List<IdentityUserClaim<Guid>> userClaims)
        {
            if (!userClaims.Any())
            {
                return user;
            }

            user.IsAdmin = userClaims.Any(claim => claim.ClaimType == AuthConstants.ClaimTypes.IsAdmin &&
                                                   claim.ClaimValue == true.ToString());

            return user;
        }

        private static Guid? TryGetIdClaim(
            IEnumerable<IdentityUserClaim<Guid>> claims,
            Func<IdentityUserClaim<Guid>, bool> claimPredicate)
        {
            var claimValue = claims
                .FirstOrDefault(claimPredicate)?
                .ClaimValue;

            return claimValue != null ? Guid.Parse(claimValue) : (Guid?)null;
        }
    }
}