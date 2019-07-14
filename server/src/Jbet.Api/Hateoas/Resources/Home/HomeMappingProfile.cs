using AutoMapper;
using Jbet.Domain.Views.Home;

namespace Jbet.Api.Hateoas.Resources.Home
{
    public class HomeMappingProfile : Profile
    {
        public HomeMappingProfile()
        {
            CreateMap<HomeView, HomeResource>(MemberList.Destination);
        }
    }
}