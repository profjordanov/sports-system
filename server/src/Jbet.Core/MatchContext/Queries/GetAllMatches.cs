using Jbet.Core.Base;
using Jbet.Domain.Views.Match;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbet.Core.MatchContext.Queries
{
    public class GetAllMatches : IQuery<IList<MatchView>>
    {
        [Range(0, 20)]
        public int StartPage { get; set; }

        [Range(0, 20)]
        public int Limit { get; set; }
    }
}