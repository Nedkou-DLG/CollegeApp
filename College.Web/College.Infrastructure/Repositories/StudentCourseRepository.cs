using System;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;

namespace College.Infrastructure.Repositories
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(CollegeContext context) : base(context)
        {
        }
    }
}

