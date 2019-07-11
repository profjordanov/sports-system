using System;
using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Views;
using Optional;

namespace Jbet.Core.AuthContext.Queries
{
    public class GetUser : IQuery<Option<UserView, Error>>
    {
        public Guid Id { get; set; }
    }
}