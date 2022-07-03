using System;
using AutoMapper;
using College.Domain.Entities;
using College.Domain.Models.Teacher;

namespace College.API.Configurations
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            //Model to Entity
            CreateMap<CreateTeacherModel, Teacher>();

            //Entity to Model

            CreateMap<Teacher, TeacherModel>();
        }
    }
}

