namespace Jbet.Api.Hateoas
{
    public static class LinkNames
    {
        public const string Self = "self";

        public static class Auth
        {
            public const string Login = "login";
            public const string Register = "register";
            public const string GetCurrentUser = "get-current-user";
            public const string Logout = "logout";
        }
    }
}