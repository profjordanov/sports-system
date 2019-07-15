using Jbet.Core.Base;
using Jbet.Domain;
using Jbet.Domain.Views.Match;
using Optional;
using System;

namespace Jbet.Core.MatchContext.Queries
{
    public class GetMatchDetails : IQuery<Option<MatchDetailsView, Error>>
    {
        public GetMatchDetails(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}