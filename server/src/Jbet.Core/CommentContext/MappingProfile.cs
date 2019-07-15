using AutoMapper;
using Jbet.Domain.Entities;
using Jbet.Domain.Views.Comment;

namespace Jbet.Core.CommentContext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentView>(MemberList.Destination)
                .ForMember(
                    dest => dest.Username,
                    opts => opts.MapFrom(src => src.User.UserName));
        }
    }
}