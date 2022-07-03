using System;
namespace College.Domain.Interfaces.Repositories
{
	public interface IUnitOfWork
	{
		ITeacherRepository TeacherRepository { get; }
		IDepartmentRepository DepartmentRepository { get; }
		ICourseRepository CourseRepository { get; }
		IStudentRepository StudentRepository { get; }
		IUserRepository UserRepository { get; }
		IStudentCourseRepository StudentCourseRepository { get; }
		void Save();
		Task SaveAsync();
	}
}

