using DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DBContexts
{
    public class MemberProfileContext:DbContext
    {
        public DbSet<Member>Members{ get; set; }
        public DbSet<Studio> Studios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString; ;
            optionsBuilder.UseMySQL(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
