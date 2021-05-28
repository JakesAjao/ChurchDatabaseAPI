using ChurchDatabaseAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
        }
        public DbSet<MemberRequest> Membership { get; set; }
        //public DbSet<Member> Member { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Mail> Mail { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(u => u.Username)
               .IsUnique();
            modelBuilder.Entity<User>()
              .HasIndex(u => u.Email)
              .IsUnique();
        }
    }
}
