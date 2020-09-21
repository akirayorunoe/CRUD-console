using AutoMapper;
using NETCORE.DatabaseAccess.Models;
using System;

namespace NETCORE
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Member, MemberDTO>() // means you want to map from Member to MemberDTO// .ForMember(dest => dest.Intro, opt => opt.MapFrom<CustomResolver>());
            .ForMember(dest => dest.Intro, opt => opt.MapFrom(src => DateTime.Today.Subtract(src.CreateDate) <= new TimeSpan(7, 0, 0, 0)));
        }
    }
}
