using DatabaseAccess.Models;
using System;
using System.Collections.Generic;

namespace DatabaseAccess.Repositories
{
    public interface IMemberRepository
    {
        List<Member> GetAll();
        List<Member> GetAll(Func<Member, bool> expression);
        Member GetById(int memberId);
        void Create(Member member);
        //List<Members> Read();
        void Update(Member member, Member updateMember);
        void Delete(int index);
        List<Member> ShowListMemberOfStudio(int studioId);
    }
}
