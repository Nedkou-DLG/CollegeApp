using System;
using College.Domain.Models.Course;

namespace College.API.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseModel>> GetAll();
        Task CreateCourse(CreateCourseModel model);
    }
}

