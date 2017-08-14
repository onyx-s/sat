using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnyxSAT.Models;

namespace OnyxSAT.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

             builder.Entity<CourseUnit>()
                .HasKey(c => new { c.UnitCode, c.CourseCode });

            builder.Entity<TeachingPeriod>()
                .HasKey(c => new { c.Period, c.Year });     
        }

        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<CourseUnit> CourseUnits { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TeachingPeriod> TeachingPeriods { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OnyxSAT.Models.User> User { get; set; }
    }
}
