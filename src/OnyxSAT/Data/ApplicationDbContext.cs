using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
// using OnyxSAT.Models;

namespace OnyxSAT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<User> Users { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Attendance> Attendances { get; set; }
        // public DbSet<Card> Cards { get; set; }
        // public DbSet<Location> Locations { get; set; }
    }
}
