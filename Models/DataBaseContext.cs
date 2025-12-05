using Microsoft.EntityFrameworkCore;
using SchoolProject.Models.Entities;

namespace SchoolProject.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get;set; }
    } 
}
