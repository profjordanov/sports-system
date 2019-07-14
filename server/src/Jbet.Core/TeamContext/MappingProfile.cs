using System.Linq;
using AutoMapper;
using Jbet.Domain.Entities;
using Jbet.Domain.Views.Team;

namespace Jbet.Core.TeamContext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamView>(MemberList.Destination)
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(m => m.Votes.Any() ? m.Votes.Sum(v => v.Value) : 0));
        }
    }
}