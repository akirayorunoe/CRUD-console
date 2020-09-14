using NETCORE.DatabaseAccess.Models;
using System.Collections.Generic;

namespace NETCORE.Services
{
    public interface IMapperService
    {
        List<MemberDTO> GetListMemberDTOs(List<Member> members);
        MemberDTO GetMemberDTOs(Member member);
    }
}
