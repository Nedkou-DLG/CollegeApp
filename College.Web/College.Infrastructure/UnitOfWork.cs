using System;
using College.Domain.Interfaces.Repositories;
using College.Infrastructure.Repositories;

namespace College.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
        protected readonly CollegeContext context;
        private ITeacherRepository teacherRepository;
        private IDepartmentRepository departmentRepository;
        private ICourseRepository courseRepository;
        private IStudentRepository studentRepository;

		public UnitOfWork(CollegeContext context)
		{
            this.context = context;
		}

        public ITeacherRepository TeacherRepository
        {
            get
            {
                if(this.teacherRepository == null)
                {
                    this.teacherRepository = new TeacherRepository(context);
                }
                return this.teacherRepository;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if(this.departmentRepository == null)
                {
                    this.departmentRepository = new DepartmentRepository(context);
                }
                return this.departmentRepository;
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                if(this.courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(context);
                }
                return this.courseRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if(this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(context);
                }
                return this.studentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

