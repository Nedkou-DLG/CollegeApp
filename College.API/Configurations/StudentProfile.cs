using System;
using AutoMapper;
using College.Domain.Entities;
using College.Domain.Models;

namespace College.API.Configurations
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			// Entity To Model
			CreateMap<Student, StudentModel>();

			//Model To Entitiy
			CreateMap<StudentModel, Student>();
		}
	}
}

