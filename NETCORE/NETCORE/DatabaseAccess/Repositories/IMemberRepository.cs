using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.DatabaseAccess.Repositories
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAll();
        Task<List<Member>> GetAll(Func<Member, bool> expression);
        Task<Member> Get(int memberId);
        Task<Member> Create(Member member);
        //List<Members> Read();
        Task<Member> Update(int id,Member updateMember);
        Task<Member> Delete(int id);
        Task<List<Member>> ShowListMemberOfStudio(int studioId);
    }
}
