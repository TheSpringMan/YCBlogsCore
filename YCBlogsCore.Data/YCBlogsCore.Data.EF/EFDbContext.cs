using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YCBlogsCore.Domain.Models;

namespace YCBlogsCore.Data.EF
{
    public class EFDbContext:DbContext,IDisposable
    {
        public EFDbContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Utils.GlobalContext.DbConfig.ConnectionString);
            optionsBuilder.AddInterceptors(new CustomDbCommandInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(sc => new { sc.UserId, sc.RoleId});
            modelBuilder.Entity<UserRole>().HasOne<User>(sc => sc.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserRole>().HasOne<Role>(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
