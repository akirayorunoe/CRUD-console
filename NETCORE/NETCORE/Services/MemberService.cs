using AutoMapper;
using NETCORE.DatabaseAccess.DBContext;
using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;
using System.Collections.Generic;

namespace NETCORE.Services
{
    public class MemberService : MemberRepository, IMemberService
    {
        private readonly IMapper _mapper;
        public MemberService(MemberProfileContext ctx,IMapper mapper):base(ctx)//https://stackoverflow.com/questions/57203893/how-to-fix-there-is-no-argument-given-that-corresponds-to-the-required-formal-p
        {
            _mapper = mapper;
        }

        public List<MemberDTO> GetListMemberDTOs(List<Member> members)
        {
            return _mapper.Map<List<MemberDTO>>(members); 
        }

        public MemberDTO GetMemberDTOs(Member member)
        {
            return _mapper.Map<MemberDTO>(member);
        }
    }
}
