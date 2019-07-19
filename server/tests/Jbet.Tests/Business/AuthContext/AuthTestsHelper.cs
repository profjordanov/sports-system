using Jbet.Core.AuthContext.Commands;
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
    }
}