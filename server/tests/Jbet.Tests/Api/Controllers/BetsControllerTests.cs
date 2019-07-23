using System.Threading.Tasks;
using AutoFixture;
using Jbet.Tests.Customizations;
using Xunit;

namespace Jbet.Tests.Api.Controllers
{
    public class BetsControllerTests : ResetDatabaseLifetime
    {
        [Theory]
        [CustomizedAutoData]
        public async Task BetForAwayTeamShouldReturnProperHypermediaLinks(Fixture fixture)
        {
            
        }
    }
}