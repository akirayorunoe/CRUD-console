using Microsoft.EntityFrameworkCore;
using NETCORE.DatabaseAccess.DBContext;
using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.DatabaseAccess.Repositories
{
    public class MemberRepository:IMemberRepository
    {
        private MemberProfileContext _DBContext;
        public MemberRepository(MemberProfileContext context)
        {
            _DBContext = context;
        }

        async Task<Member> IMemberRepository.Create(Member member)
        {
            Guid g = Guid.NewGuid();
            member.MemberUUId = g.ToString();
            _DBContext.Members.Add(member);
            await _DBContext.SaveChangesAsync();
            return member;
        }

        async Task<Member> IMemberRepository.Update(int id, Member updateMember)
        {
            var member = await _DBContext.Members.FindAsync(id);
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
            await _DBContext.SaveChangesAsync();
            return member;

        }

        async Task<Member> IMemberRepository.Delete(int id)
        {
            var member = await _DBContext.Members.FindAsync(id); 
            if (member == null)
            {
                return member;
            }
            _DBContext.Remove(member);
            await _DBContext.SaveChangesAsync();
            return member;
        }

        async Task<List<Member>> IMemberRepository.GetAll(Func<Member, bool> expression)
        {
            if (expression != null)
                 return _DBContext.Members.Where(expression).ToList();
            else return await _DBContext.Members.ToListAsync();
        }


        async Task<List<Member>> IMemberRepository.GetAll()
        {
            return await _DBContext.Members.ToListAsync();
        }

        async Task<List<Member>> IMemberRepository.ShowListMemberOfStudio(int studioId)
        {
            var listMembers = _DBContext.Members.Where(mem => mem.StudioId == studioId);
            return await listMembers.ToListAsync();
        }

        async Task<Member> IMemberRepository.Get(int memberId)
        {
            return await _DBContext.Members.FirstOrDefaultAsync(mem => mem.MemberId == memberId);
        }
    }
}
