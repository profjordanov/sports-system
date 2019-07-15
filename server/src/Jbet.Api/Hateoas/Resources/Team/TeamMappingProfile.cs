using AutoMapper;
using Jbet.Domain.Views.Team;

namespace Jbet.Api.Hateoas.Resources.Team
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<TeamDetailsView, TeamDetailsResource>(MemberList.Destination);
        }
    }
}