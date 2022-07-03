using System;
using AutoMapper;
using College.Domain.Entities;
using College.Domain.Models.Course;

namespace College.API.Configurations
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //Entity to Model
            CreateMap<Course, CourseModel>();

            //Model To Entity
            CreateMap<CreateCourseModel, Course>();
        }
    }
}

