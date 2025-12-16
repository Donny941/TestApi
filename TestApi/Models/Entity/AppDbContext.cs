using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TestApi.Models.Entity
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentProfile> StudentProfile { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
