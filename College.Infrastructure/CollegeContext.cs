using System;
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
	}
}

