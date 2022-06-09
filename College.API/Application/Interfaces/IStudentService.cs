using System;
using College.Domain.Entities;
using College.Domain.Models;

namespace College.API.Application.Interfaces
{
	public interface IStudentService
	{
		Task<StudentModel> CreateStudent(StudentModel student);
	}
}

