namespace Jbet.Core.AuthContext
{
    public static class AuthConstants
    {
        public static class ClaimTypes
        {
            public const string IsAdmin = "isAdmin";
        }

        public static class Policies
        {
            public const string IsAdmin = "IsAdmin";
        }

        public static class Cookies
        {
            public const string AuthCookieName = "access_token";
        }

        public static class Queries
        {
            public const string QueryParamAccessToken = "access_token";
        }
    }
}