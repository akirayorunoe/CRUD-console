using DatabaseAccess.DBContexts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAccess.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private MemberProfileContext _DBContext =null;
        public MemberRepository(MemberProfileContext context)
        {
            _DBContext = context;
        }

        void IMemberRepository.Create(Member member)
        {
            Guid g = Guid.NewGuid();
            member.MemberUUId = g.ToString();
            _DBContext.Members.Add(member);
            _DBContext.SaveChanges();
        }

        void IMemberRepository.Update(Member member, Member updateMember)
        {
                    member.Email = updateMember.Email;
                    member.UserName = updateMember.UserName;
                    member.FirstName = updateMember.FirstName;
                    member.LastName = updateMember.LastName;
                    member.Gender = updateMember.Gender;
                    member.BirthDate = updateMember.BirthDate;
                    member.Weight = updateMember.Weight;
                    member.StudioId = updateMember.StudioId;
                    member.StudioName = updateMember.StudioName;
                    _DBContext.Members.Update(member);
                    _DBContext.SaveChanges();
                    
               
        }

        void IMemberRepository.Delete(int i)
        {
            var member = new Member()
            {
                MemberId = i
            };
            using (var context = new MemberProfileContext())
            {
                context.Remove(member);

                context.SaveChanges();
            }
        }

        public List<Member> GetAll(Func<Member, bool> expression)
        {
            if (expression != null)
                return _DBContext.Members.Where(expression).ToList();
            else return _DBContext.Members.ToList();
        }

        public Member GetById(int memberId)
        {
            return _DBContext.Members.FirstOrDefault(mem => mem.MemberId == memberId);
        }

        public List<Member> GetAll()
        {
            return _DBContext.Members.ToList();
        }

        public List<Member> ShowListMemberOfStudio(int studioId)
        {
            var listMembers = _DBContext.Members.Where(mem => mem.StudioId == studioId);
            return listMembers.ToList();
        }
    }
}
