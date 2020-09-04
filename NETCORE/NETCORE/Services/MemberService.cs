
using NETCORE.DatabaseAccess.DBContext;
using NETCORE.DatabaseAccess.Repositories;

namespace NETCORE.Services
{
    public class MemberService : MemberRepository, IMemberService
    {
        public MemberService(MemberProfileContext ctx):base(ctx)//https://stackoverflow.com/questions/57203893/how-to-fix-there-is-no-argument-given-that-corresponds-to-the-required-formal-p
        {
        }
    }
}
