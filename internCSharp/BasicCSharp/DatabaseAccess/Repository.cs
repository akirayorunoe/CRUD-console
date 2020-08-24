using DataAccess;
using DatabaseAccess.DBContexts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseAccess
{
    public class Repository: IRepository
    {
        private Context _DBContext = new Context();
        public Repository()
        {
        }

        void IRepository.CreateMember(Member member)
        {
            Guid g = Guid.NewGuid();
            member.MemberUUId = g.ToString();
            _DBContext.Members.Add(member);
            _DBContext.SaveChanges();
        }

        void IRepository.UpdateMember(int i, Member updateMember)
        {
            foreach (var member in _DBContext.Members.ToList())
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
                    member.StudioId = updateMember.StudioId;
                    member.StudioName = updateMember.StudioName;
                    member.show();
                    _DBContext.Members.Update(member);
                    _DBContext.SaveChanges();
                    
                }
            } 

               
        }

        void IRepository.DeleteMember(int i)
        {
            var member = new Member()
            {
                MemberId = i
            };
            using (var context = new Context())
            {
                context.Remove(member);

                context.SaveChanges();
            }
        }

        public List<Member> GetAllMember(Func<Member, bool> expression)
        {
            if (expression != null)
                return _DBContext.Members.Where(expression).ToList();
            else return _DBContext.Members.ToList();
        }

        public Member GetMemberByMemberId(int memberId)
        {
            var member = _DBContext.Members.FirstOrDefault(mem => mem.MemberId == memberId);
            return member;
        }

        public List<Member> GetAllMember()
        {
            return _DBContext.Members.ToList();
        }

        public List<Studio> GetAllStudio()
        {
            return _DBContext.Studios.ToList();
        }

        public Studio GetStudioByStudioId(int studioId)
        {
            var studio = _DBContext.Studios.FirstOrDefault(stu => stu.StudioId == studioId);
            return studio;
        }

        public void CreateStudio(Studio studio)
        {
            _DBContext.Studios.Add(studio);
            _DBContext.SaveChanges();
        }

        public void UpdateStudio(int index, Studio updateStudio)
        {
            
            foreach (var studio in _DBContext.Studios.ToList())
            {
                if (studio.StudioId == index)
                {
                    studio.StudioName = updateStudio.StudioName;
                    studio.ManagerEmail = updateStudio.ManagerEmail;
                    studio.Address = updateStudio.Address;
                    studio.show();
                    _DBContext.Studios.Update(studio);
                    _DBContext.SaveChanges();

                }
            }
        }

        public void DeleteStudio(int index)
        {
            var studio = new Studio()
            {
                StudioId = index
            };
            _DBContext.Studios.Remove(studio);
        }

        public List<Member> ShowListMemberOfStudio(int studioId)
        {
            var listMembers = _DBContext.Members.Where(mem => mem.StudioId == studioId);
            return listMembers.ToList();
        }
        public Studio GetStudio(Func<Studio, bool> expression)
        {
            if (expression != null)
                return _DBContext.Studios.FirstOrDefault(expression);
            else return null;
        }
    }
}
