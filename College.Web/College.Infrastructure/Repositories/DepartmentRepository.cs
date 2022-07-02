using System;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;

namespace College.Infrastructure.Repositories
{
	public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
	{
		public DepartmentRepository(CollegeContext context) : base(context)
		{
		}
	}
}

