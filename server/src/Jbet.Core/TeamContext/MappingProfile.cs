using System.Collections.Generic;
using AutoMapper;
using Jbet.Domain.Entities;
using Jbet.Domain.Views.Team;
using System.Linq;
using Jbet.Domain.Views.Player;

namespace Jbet.Core.TeamContext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamView>(MemberList.Destination)
                .ForMember(
                    dest => dest.Votes,
                    cnf => cnf.MapFrom(src => src.Votes.Any() ? src.Votes.Sum(v => v.Value) : 0));

            CreateMap<Team, TeamDetailsView>(MemberList.None)
                .ForMember(
                    dest => dest.Votes,
                    cnf => cnf.MapFrom(src => src.Votes.Any() ? src.Votes.Sum(v => v.Value) : 0))
                .ForMember(
                    dest => dest.Players,
                    cnf => cnf.MapFrom(src => src.Players))
                .ForMember(
                    dest => dest.UserHasVoted,
                    cnf => cnf.Ignore());
        }
    }
}