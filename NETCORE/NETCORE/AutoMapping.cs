using AutoMapper;
using NETCORE.DatabaseAccess.Models;

namespace NETCORE
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Member, MemberDTO>() // means you want to map from Member to MemberDTO
                .ForMember(dest => dest.Intro, opt => opt.MapFrom<CustomResolver>());
        }
    }
}
