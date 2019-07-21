using AutoFixture;
using Jbet.Domain.Entities;
using System;

namespace Jbet.Tests.Customizations
{
    public class TeamCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Team>(composer => 
                composer.FromFactory(() => new Team
                {
                    Id = Guid.NewGuid(),
                }).Without(r => r.Id)
                    .Without(team => team.AwayMatches)
                    .Without(team => team.HomeMatches)
                    .Without(team => team.Votes)
                    .Without(team => team.Players));
        }
    }
}