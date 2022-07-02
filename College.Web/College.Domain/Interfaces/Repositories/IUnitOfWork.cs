using System;
namespace College.Domain.Interfaces.Repositories
{
	public interface IUnitOfWork
	{
		ITeacherRepository TeacherRepository { get; }
		IDepartmentRepository DepartmentRepository { get; }
		ICourseRepository CourseRepository { get; }
		IStudentRepository StudentRepository { get; }
		void Save();
		Task SaveAsync();
	}
}

