using System;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;

namespace College.Infrastructure.Repositories
{
	public class CourseRepository : GenericRepository<Course>, ICourseRepository
	{
		public CourseRepository(CollegeContext context) : base(context)
		{
		}
	}
}

