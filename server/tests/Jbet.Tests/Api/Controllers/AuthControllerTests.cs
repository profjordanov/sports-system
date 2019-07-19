using Jbet.Api.Hateoas.Resources.Auth;
using Jbet.Core.AuthContext;
using Jbet.Core.AuthContext.Commands;
using Jbet.Tests.Business.AuthContext;
using Jbet.Tests.Customizations;
using Jbet.Tests.Extensions;
using Shouldly;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Jbet.Tests.Api.Controllers
{
    public class AuthControllerTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;
        private readonly ApiTestsHelper _apiHelper;
        private readonly AuthTestsHelper _authHelper;

        public AuthControllerTests()
        {
            _fixture = new AppFixture();
            _apiHelper = new ApiTestsHelper(_fixture);
            _authHelper = new AuthTestsHelper(_fixture);
        }

        [Theory]
        [CustomizedAutoData]
        public async Task LoginShouldSetProperHttpOnlyCookie(Register register)
        {
            // Arrange
            await _authHelper.Register(register);

            var loginCommand = new Login
            {
                Email = register.Email,
                Password = register.Password
            };

            // Act
            var response = await _fixture.ExecuteHttpClientAsync(client =>
                client.PostAsJsonAsync(AuthRoute("login"), loginCommand));

            // Assert
            var token = (await response
                    .ShouldDeserializeTo<LoginResource>())
                .TokenString;

            response.Headers.ShouldContain(header =>
                header.Key == "Set-Cookie" &&
                header.Value.Any(x => x.Contains(AuthConstants.Cookies.AuthCookieName) && x.Contains(token)));
        }

        private static string AuthRoute(string route = null) =>
            $"/auth/{route?.TrimStart('/') ?? string.Empty}";
    }
}