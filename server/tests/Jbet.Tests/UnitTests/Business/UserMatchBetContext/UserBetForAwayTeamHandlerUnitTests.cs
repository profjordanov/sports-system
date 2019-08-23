using AutoMapper;
using FluentValidation;
using Jbet.Business.UserMatchBetContext.CommandHandlers;
using Jbet.Core.UserMatchBetContext.Commands;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using Jbet.Tests.Extensions;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Jbet.Tests.UnitTests.Business.UserMatchBetContext
{
    public class UserBetForAwayTeamHandlerUnitTests
    {
        private UserBetForAwayTeamHandler _betForAwayTeamHandler;

        private readonly Mock<IValidator<UserBetForAwayTeam>> _validatorMock;
        private readonly Mock<IEventBus> _eventBusMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IBetsRepository> _betsRepositoryMock;

        public UserBetForAwayTeamHandlerUnitTests()
        {
            _validatorMock = new Mock<IValidator<UserBetForAwayTeam>>();
            _eventBusMock = new Mock<IEventBus>();
            _mapperMock = new Mock<IMapper>();
            _betsRepositoryMock = new Mock<IBetsRepository>();

            _betForAwayTeamHandler = new UserBetForAwayTeamHandler(
                _validatorMock.Object,
                _eventBusMock.Object,
                _mapperMock.Object,
                _betsRepositoryMock.Object);
        }

        [Fact]
        public async Task Handler_Should_Return_Critical_Error_If_Repository_Crashes()
        {
            // Arrange
            var command = new UserBetForAwayTeam
            {
                UserId = Guid.NewGuid(),
                MatchId = Guid.NewGuid(),
                AwayBet = decimal.MaxValue,
            };

            _betsRepositoryMock
                .Setup(repository => repository
                    .AddAwayBetAsync(command.UserId, command.MatchId, command.AwayBet))
                    .ReturnsAsync(() => null);

            // Act
            var result = await _betForAwayTeamHandler.Handle(command);

            // Assert
            result.ShouldHaveErrorOfType(ErrorType.Critical);
        }

        [Fact]
        public async Task Handler_Should_Work_Properly()
        {
            // Arrange
            var command = new UserBetForAwayTeam
            {
                UserId = Guid.NewGuid(),
                MatchId = Guid.NewGuid(),
                AwayBet = decimal.MaxValue,
            };

            var userMatchBet = new UserMatchBet
            {
                Id = Guid.NewGuid(),
                UserId = command.UserId,
                MatchId = command.MatchId,
                AwayBet = command.AwayBet,
                HomeBet = decimal.Zero,
            };

            _betsRepositoryMock
                .Setup(repository => repository
                    .AddAwayBetAsync(command.UserId, command.MatchId, command.AwayBet))
                    .ReturnsAsync(() => userMatchBet);

            // Act
            var result = await _betForAwayTeamHandler.Handle(command);

            // Assert
            result.HasValue.ShouldBe(true);
        }
    }
}