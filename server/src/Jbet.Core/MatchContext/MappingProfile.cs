using AutoMapper;
using Jbet.Domain.Entities;
using Jbet.Domain.Views.Match;

namespace Jbet.Core.MatchContext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Match, MatchView>(MemberList.Destination)
                .ForMember(
                    dest => dest.HomeTeamName,
                    opts => opts.MapFrom(src => src.HomeTeam.Name))
                .ForMember(
                    dest => dest.AwayTeamName,
                    opts => opts.MapFrom(src => src.AwayTeam.Name));
        }
    }
}