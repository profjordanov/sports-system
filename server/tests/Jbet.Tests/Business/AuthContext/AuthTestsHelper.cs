using System;
using System.Collections.Generic;
using System.Security.Claims;
using Jbet.Core.AuthContext.Commands;
using System.Threading.Tasks;
using Jbet.Domain.Entities;
using Jbet.Domain.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Jbet.Tests.Business.AuthContext
{
    public class AuthTestsHelper
    {
        private readonly AppFixture _fixture;

        public AuthTestsHelper(AppFixture fixture)
        {
            _fixture = fixture;
        }

        public Task Register(Register command) =>
            _fixture.SendAsync(command);

        public async Task AddClaimsAsync(Guid userId, IEnumerable<Claim> claims)
        {
            await _fixture.ExecuteScopeAsync(async sp =>
            {
                var userManager = sp.GetRequiredService<UserManager<User>>();

                var user = await userManager.FindByIdAsync(userId.ToString());

                if (user != null)
                {
                    await userManager.AddClaimsAsync(user, claims);
                }
            });
        }

        public async Task<JwtView> Login(string email, string password) =>
            (await _fixture.SendAsync(new Login
            {
                Email = email,
                Password = password
            }))
            .ValueOr(() => throw new InvalidOperationException("Tried to login with invalid credentials."));
    }
}