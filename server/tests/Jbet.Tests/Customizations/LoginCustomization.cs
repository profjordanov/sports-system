using AutoFixture;
using Jbet.Core.AuthContext.Commands;
using System.Net.Mail;

namespace Jbet.Tests.Customizations
{
    public class LoginCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Login>(composer =>
                composer.With(c => c.Email, fixture.Create<MailAddress>().Address));
        }
    }
}