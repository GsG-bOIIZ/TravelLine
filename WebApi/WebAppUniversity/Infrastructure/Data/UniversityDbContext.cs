using Microsoft.EntityFrameworkCore;
using WebAppUniversity.Domain;
using WebAppUniversity.Infrastructure.Configurations;

namespace WebAppUniversity.Infrastructure
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Group> Class { get; set; }
        public DbSet<Student> Student { get; set; }


        public UniversityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacultyMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
        }
    }
}
