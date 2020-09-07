using Microsoft.EntityFrameworkCore;
using NETCORE.DatabaseAccess.Models;
using System.Configuration;

namespace NETCORE.DatabaseAccess.DBContext
{
    public class MemberProfileContext:DbContext
    {
        public MemberProfileContext(DbContextOptions<MemberProfileContext> options)
            : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Studio> Studios { get; set; }
    }
}
