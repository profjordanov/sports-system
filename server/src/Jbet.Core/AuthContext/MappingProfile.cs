using AutoMapper;
using Jbet.Core.AuthContext.Commands;
using Jbet.Domain.Entities;
using Jbet.Domain.Views;

namespace Jbet.Core.AuthContext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, User>(MemberList.Source)
                .ForMember(d => d.UserName, opts => opts.MapFrom(s => s.Email))
                .ForSourceMember(s => s.Password, opts => opts.DoNotValidate());

            CreateMap<User, UserView>(MemberList.Destination);
        }
    }
}