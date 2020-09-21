using AutoMapper;
using NETCORE.DatabaseAccess.Models;
using System;
namespace NETCORE
{
    public class CustomResolver : IValueResolver<Member, MemberDTO, bool>
    {
        public bool Resolve(Member source, MemberDTO destination, bool destMember, ResolutionContext context)
        {
            TimeSpan t = new TimeSpan(7, 0, 0, 0);
            if (DateTime.Now.Subtract(source.CreateDate) >= t)
            {
               return true;
            }
            return false;
        }
    }
}
