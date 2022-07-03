using System;
using AutoMapper;
using College.Domain.Entities;
using College.Domain.Models.Student;
using College.Domain.Models.Teacher;

namespace College.API.Configurations
{
    public class UserProfile : Profile
    {
        
        public UserProfile()
        {
            //Model to Entity

            CreateMap<CreateTeacherModel, UserRecord>();
            CreateMap<CreateStudentModel, UserRecord>();
        }
    }
}

