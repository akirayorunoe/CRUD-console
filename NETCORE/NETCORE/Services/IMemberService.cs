using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;
using System.Collections.Generic;

namespace NETCORE.Services
{
    public interface IMemberService 
    {
        public List<MemberDTO> GetListMemberDTOs(List<Member> members);

        public MemberDTO GetMemberDTOs(Member member);
        public List<MemberDTO> GetAll();
        public MemberDTO Get(int id);
        public MemberDTO Create(Member member);
        public MemberDTO Update(int id,Member member);
        public MemberDTO Delete(int id);
    }
}
