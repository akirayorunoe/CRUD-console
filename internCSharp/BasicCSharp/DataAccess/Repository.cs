using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private List<Member> Members = null;

        public Repository()
        {
            string json = File.ReadAllText("data.json");
            Members = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Member>>(json);
        }

        void IRepository.Create(Member member)
        {
            member.MemberId = Members[Members.Count - 1].MemberId + 1;
            Guid g = Guid.NewGuid();
            member.MemberUUId = g.ToString();
            Members.Add(member);
        }

        void IRepository.Update(int i, Member updateMember)
        {
            foreach (var member in Members)
            {
                if (member.MemberId == i)
                {
                    member.Email = updateMember.Email;
                    member.UserName = updateMember.UserName;
                    member.FirstName = updateMember.FirstName;
                    member.LastName = updateMember.LastName;
                    member.Gender = updateMember.Gender;
                    member.Weight = updateMember.Weight;
                }
            }
        }

        void IRepository.Delete(int i)
        {
            Members.RemoveAll(member=>member.MemberId==i);
        }

        public List<Member> GetAll(Func<Member, bool> expression)
        {
            if (expression != null)
                return Members.Where(expression).ToList();
            else return Members;
        }

        public Member GetMemberByMemberId(int memberId)
        {
            var member = Members.FirstOrDefault(mem => mem.MemberId == memberId);
            return member;
        }

        public List<Member> GetAll()
        {
            return Members;
        }
    }
}
