using System;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;

namespace College.Infrastructure.Repositories
{
	public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		public StudentRepository(CollegeContext context) : base(context)
		{
		}
	}
}

