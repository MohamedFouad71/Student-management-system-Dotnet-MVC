using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class UniversityContext : DbContext
    {
        // Tables 
        public DbSet<Student> Students { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        // this takes the options from the AddDbContext and pass it to the base constructor in DbContext
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {

        }

        // Configurations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // Fluent api: Here we can make more complex operations than data annotations, like composite keys
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
