using AutoMapper;
using Jbet.Domain.Views.Match;

namespace Jbet.Api.Hateoas.Resources.Match
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<MatchView, MatchResource>(MemberList.Destination);
        }
    }
}