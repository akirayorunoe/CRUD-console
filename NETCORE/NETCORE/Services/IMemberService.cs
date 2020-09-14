using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;
using System.Collections.Generic;

namespace NETCORE.Services
{
    public interface IMemberService : IMemberRepository
    {
        public List<MemberDTO> GetListMemberDTOs(List<Member> members);

        public MemberDTO GetMemberDTOs(Member member);

    }
}
