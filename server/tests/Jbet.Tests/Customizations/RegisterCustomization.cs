using System;
using AutoFixture;
using Jbet.Core.AuthContext.Commands;

namespace Jbet.Tests.Customizations
{
    public class RegisterCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Register>(composer =>
                composer.FromFactory(() => new Register
                    {
                        Id = Guid.NewGuid(),
                        Email = $"Email{Guid.NewGuid()}@example.com"
                    })
                    .Without(r => r.Id)
                    .Without(r => r.Email));
        }
    }
}