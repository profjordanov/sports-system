using System;

namespace Jbet.Domain.Views
{
    public class UserView
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}