using System;
using College.Domain.Entities;
using College.Domain.Models;
using College.Domain.Models.Student;

namespace College.API.Application.Interfaces
{
	public interface IStudentService
	{
		Task CreateStudent(CreateStudentModel student);
		Task<IEnumerable<StudentModel>> GetAll();
		Task<IEnumerable<StudentCourseModel>> GetStudentCourses(int id);
		Task ApplyCourse(int courseId, int studentId);
	}
}

