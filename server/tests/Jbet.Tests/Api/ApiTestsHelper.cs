using Jbet.Tests.Business.AuthContext;

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
    }
}