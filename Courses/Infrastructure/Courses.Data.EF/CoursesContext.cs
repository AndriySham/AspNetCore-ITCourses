using Microsoft.EntityFrameworkCore;


namespace Courses.Data.EF
{
    public class CoursesContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public CoursesContext(DbContextOptions<CoursesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}