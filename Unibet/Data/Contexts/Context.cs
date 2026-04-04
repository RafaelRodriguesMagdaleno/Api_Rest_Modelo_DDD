using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Unibet.Entities;

namespace Unibet.Data.Contexts
{
    public class Context : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Deposit> Deposits;

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(usr => usr.Id);

            modelBuilder.Entity<Deposit>()
                .HasKey(dpst => dpst.Id);

            modelBuilder.Entity<Deposit>()
                .HasOne(dpst => dpst.User)
                .WithMany(usr => usr.Deposits)
                .HasForeignKey(usr => usr.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
