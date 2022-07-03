using System;
using College.API.Application.Interfaces;
using College.API.Application.Services;
using College.Domain.Interfaces.Repositories;
using College.Infrastructure;

namespace College.API.Configurations
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseService>();
        }

        public static void RegisterModelMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(
           typeof(StudentProfile),
           typeof(DepartmentProfile),
           typeof(TeacherProfile),
           typeof(UserProfile),
           typeof(CourseProfile));
        }
    }
}

