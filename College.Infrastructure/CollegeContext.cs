using College.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure
{
    public class CollegeContext : DbContext
	{
        public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<StudentCourse> StudentsCourses { get; set; }

        public CollegeContext(DbContextOptions<CollegeContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>()
                .HasOne(x => x.Manager)
                .WithOne(x => x.DepartmentManager)
                .HasForeignKey<Teacher>(x => x.DepartmentManagerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.EmployeedByDepartment)
                .WithMany(x => x.Teachers).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(bc => new { bc.StudentId, bc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.Courses)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(bc => bc.StudentId);
        }
	}
}

