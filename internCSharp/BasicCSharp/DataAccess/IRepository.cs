using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRepository
    {
        List<Member> GetAll();
        List<Member> GetAll(Func<Member,bool> expression);
        Member GetMemberByMemberId(int memberId);
        void Create(Member member);
        //List<Members> Read();
        void Update(int index,Member member);
        void Delete(int index);
    }
}
