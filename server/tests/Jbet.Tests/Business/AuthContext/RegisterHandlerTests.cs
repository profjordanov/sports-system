using System.Threading.Tasks;
using Jbet.Core.AuthContext.Commands;
using Jbet.Domain;
using Jbet.Tests.Customizations;
using Jbet.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Jbet.Tests.Business.AuthContext
{
    public class RegisterHandlerTests : ResetDatabaseLifetime
    {
        private readonly AppFixture _fixture;

        public RegisterHandlerTests()
        {
            _fixture = new AppFixture();
        }

        [Theory]
        [CustomizedAutoData]
        public async Task CannotRegisterWithInvalidEmail(Register command)
        {
            // Arrange
            command.Email = "invalid-email";

            // Act
            var result = await _fixture.SendAsync(command);

            // Assert
            result.ShouldHaveErrorOfType(ErrorType.Validation);
        }
    }
}