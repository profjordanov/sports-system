using System.Linq;
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

            CreateMap<Match, MatchDetailsView>(MemberList.Destination)
                .ForMember(
                    dest => dest.AwayTeamName,
                    opts => opts.MapFrom(src => src.AwayTeam.Name))
                .ForMember(
                    dest => dest.HomeTeamName,
                    opts => opts.MapFrom(src => src.HomeTeam.Name))
                .ForMember(
                    dest => dest.Comments,
                    opts => opts.MapFrom(src => src.Comments))
                .ForMember(
                    dest => dest.HomeBets,
                    opts => opts.MapFrom(
                        src => src.UserMatchBets.Any() ? src.UserMatchBets.Sum(bet => bet.HomeBet) : 0))
                .ForMember(
                    dest => dest.AwayBets,
                    opts => opts.MapFrom(
                        src => src.UserMatchBets.Any() ? src.UserMatchBets.Sum(bet => bet.AwayBet) : 0));
        }
    }
}