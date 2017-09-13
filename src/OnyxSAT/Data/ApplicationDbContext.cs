using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnyxSAT.Models;

namespace OnyxSAT.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<UserRole>()
         .HasKey(u => new { u.UserId, u.RoleId });

      builder.Entity<Attendance>()
         .HasKey(a => new { a.DateTime, a.CardNo });
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Card> Cards { get; set; }
  }
}
