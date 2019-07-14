using Jbet.Api.Hateoas.Resources.Base;
using Newtonsoft.Json;

namespace Jbet.Api.Hateoas.Resources.Home
{
    public class ApiRootResource : Resource
    {
        [JsonIgnore]
        public bool IsUserLoggedIn { get; set; }
    }
}