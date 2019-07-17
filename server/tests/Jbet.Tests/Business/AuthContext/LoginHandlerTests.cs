using Xunit;

namespace Jbet.Tests.Business.AuthContext
{
    public class LoginHandlerTests
    {
        private readonly AppFixture _fixture;

        public LoginHandlerTests()
        {
            _fixture = new AppFixture();
        }

        [Fact]
        public void Test2()
        {
            var x = 0;
            Assert.Equal(0, x);
        }
    }
}