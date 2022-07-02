using System;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;

namespace College.Infrastructure.Repositories
{
	public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
	{
		public TeacherRepository(CollegeContext context) : base(context)
		{
		}
	}
}

