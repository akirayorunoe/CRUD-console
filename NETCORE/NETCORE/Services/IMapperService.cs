using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.Services
{
    public interface IMapperService
    {
        List<MemberDTO> GetListMemberDTOs(List<Member> members);
        MemberDTO GetMemberDTOs(Member member);
    }
}
