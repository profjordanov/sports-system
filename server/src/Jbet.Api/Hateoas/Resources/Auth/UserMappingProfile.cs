using AutoMapper;
using Jbet.Domain.Views;

namespace Jbet.Api.Hateoas.Resources.Auth
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<JwtView, LoginResource>(MemberList.Destination);
            CreateMap<UserView, UserResource>(MemberList.Destination);
        }
    }
}