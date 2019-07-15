using AutoMapper;
using Jbet.Domain.Entities;
using Jbet.Domain.Views.Player;

namespace Jbet.Core.PlayerContext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerView>(MemberList.Destination);
        }
    }
}