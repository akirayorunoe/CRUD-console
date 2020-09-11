using AutoMapper;
using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.Services
{
    public class MapperService:IMapperService
    {
        private readonly IMapper _mapper;
        public MapperService(IMapper mapper) {
            _mapper = mapper;
        }

        public List<MemberDTO> GetListMemberDTOs(List<Member> members)
        {
            TimeSpan t = new TimeSpan(7, 0, 0, 0);
            var listMembers = _mapper.Map<List<MemberDTO>>(members);
            for(int i = 0; i < listMembers.Count; i++)
            {
                if (DateTime.Now.Subtract(members[i].CreateDate) >= t)
                {
                    listMembers[i].Intro = true;
                }
            }
           return listMembers;
        }

        public MemberDTO GetMemberDTOs(Member member)
        {
            TimeSpan t = new TimeSpan(7, 0, 0, 0);
            var memberDto = _mapper.Map<MemberDTO>(member);
            if(DateTime.Now.Subtract(member.CreateDate)>= t)
            {
                memberDto.Intro = true;
            }
            return memberDto;
        }
    }
}
