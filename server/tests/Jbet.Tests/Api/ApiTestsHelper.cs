using AutoFixture;
using Jbet.Core.AuthContext.Commands;
using Jbet.Tests.Business.AuthContext;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jbet.Tests.Api
{
    public class ApiTestsHelper
    {
        private readonly AppFixture _appFixture;
        private readonly AuthTestsHelper _authHelper;

        public ApiTestsHelper(AppFixture appFixture)
        {
            _appFixture = appFixture;
            _authHelper = new AuthTestsHelper(_appFixture);
        }

        public async Task InTheContextOfAnAuthenticatedUser(Func<HttpClient, Task> serverCall, Fixture fixture, IEnumerable<Claim> withClaims = null)
        {
            var token = await SetupUserWithClaims(fixture, withClaims);

            await _appFixture.ExecuteHttpClientAsync(serverCall, token);
        }

        public Task InTheContextOfAnAnonymousUser(Func<HttpClient, Task> serverCall) =>
            _appFixture.ExecuteHttpClientAsync(serverCall);

        private async Task<string> SetupUserWithClaims(Fixture fixture, IEnumerable<Claim> withClaims)
        {
            var registerCommand = fixture
                .Create<Register>();

            await _authHelper.Register(registerCommand);

            if (withClaims != null)
                await _authHelper.AddClaimsAsync(registerCommand.Id, withClaims);

            var token = (await _authHelper
                    .Login(registerCommand.Email, registerCommand.Password))
                .TokenString;

            return token;
        }
    }
}