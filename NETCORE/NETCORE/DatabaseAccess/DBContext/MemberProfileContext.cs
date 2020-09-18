using Microsoft.EntityFrameworkCore;
using NETCORE.DatabaseAccess.Models;

namespace NETCORE.DatabaseAccess.DBContext
{
    public class MemberProfileContext:DbContext
    {
        public MemberProfileContext(DbContextOptions<MemberProfileContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
    }
}
