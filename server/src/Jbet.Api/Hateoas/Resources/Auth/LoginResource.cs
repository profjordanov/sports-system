using Jbet.Api.Hateoas.Resources.Base;

namespace Jbet.Api.Hateoas.Resources.Auth
{
    public class LoginResource : Resource
    {
        public string TokenString { get; set; }
    }
}