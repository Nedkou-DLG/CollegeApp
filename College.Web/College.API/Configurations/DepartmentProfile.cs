using System;
using AutoMapper;
using College.Domain.Entities;
using College.Domain.Models.Department;

namespace College.API.Configurations
{
    public class DepartmentProfile : Profile

    {
        public DepartmentProfile()
        {
            //Entity to Model
            CreateMap<Department, DepartmentModel>()
                .ForMember(x => x.Leader, opt => opt.MapFrom(y => y.Manager));
            //Model to Entity
            CreateMap<CreateDepartmentModel, Department>();
        }
    }
}

