using Jbet.Core.AuthContext.Commands;
using Jbet.Domain.Entities;
using Jbet.Domain.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public async Task<JwtView> RegisterAndLogin(Register command)
        {
            await Register(command);
            return await Login(command.Email, command.Password);
        }
    }
}