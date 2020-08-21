using DataAccess;
using DatabaseAccess.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseAccess
{
    public class Repository: IRepository
    {
        private MemberDbContext _memberDBContext = new MemberDbContext();
        public Repository()
        {
        }

        void IRepository.Create(Member member)
        {
            Guid g = Guid.NewGuid();
            member.MemberUUId = g.ToString();
            _memberDBContext.Add(member);
            _memberDBContext.SaveChanges();
        }

        void IRepository.Update(int i, Member updateMember)
        {
            foreach (var member in _memberDBContext.Members)
            {
                if (member.MemberId == i)
                {
                        
                    member.Email = updateMember.Email;
                    member.UserName = updateMember.UserName;
                    member.FirstName = updateMember.FirstName;
                    member.LastName = updateMember.LastName;
                    member.Gender = updateMember.Gender;
                        member.BirthDate = updateMember.BirthDate;
                    member.Weight = updateMember.Weight;
                    _memberDBContext.Update(member);
                    _memberDBContext.SaveChanges();
                    
                }
            } 

               
        }

        void IRepository.Delete(int i)
        {
            var member = new Member()
            {
                MemberId = i
            };
            using (var context = new MemberDbContext())
            {
                context.Remove(member);

                context.SaveChanges();
            }
        }

        public List<Member> GetAll(Func<Member, bool> expression)
        {
            if (expression != null)
                return _memberDBContext.Members.Where(expression).ToList();
            else return _memberDBContext.Members.ToList();
        }

        public Member GetMemberByMemberId(int memberId)
        {
            var member = _memberDBContext.Members.FirstOrDefault(mem => mem.MemberId == memberId);
            return member;
        }

        public List<Member> GetAll()
        {
            return _memberDBContext.Members.ToList();
        }
    }
}
