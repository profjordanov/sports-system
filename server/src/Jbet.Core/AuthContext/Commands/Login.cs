using Jbet.Core.Base;
using Jbet.Domain.Views;

namespace Jbet.Core.AuthContext.Commands
{
    public class Login : ICommand<JwtView>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}