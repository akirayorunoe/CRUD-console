using DataAccess;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess
{
    public interface IRepository
    {
        List<Member> GetAllMember();
        List<Member> GetAllMember(Func<Member, bool> expression);
        Member GetMemberByMemberId(int memberId);
        void CreateMember(Member member);
        //List<Members> Read();
        void UpdateMember(int index, Member member);
        void DeleteMember(int index);
        List<Studio> GetAllStudio();
        Studio GetStudioByStudioId(int studioId);
        void CreateStudio(Studio studio);
        //List<Members> Read();
        void UpdateStudio(int index, Studio studio);
        void DeleteStudio(int index);
        List<Member> ShowListMemberOfStudio(int studioId);
        Studio GetStudio(Func<Studio, bool> expression);
    }
}
