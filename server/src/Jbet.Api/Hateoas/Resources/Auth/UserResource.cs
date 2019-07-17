using Jbet.Api.Hateoas.Resources.Base;
using System;

namespace Jbet.Api.Hateoas.Resources.Auth
{
    public class UserResource : Resource
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }
    }
}