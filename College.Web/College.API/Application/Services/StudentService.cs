using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.API.Application.Interfaces;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models;
using College.Domain.Models.Course;
using College.Domain.Models.Student;
using Microsoft.EntityFrameworkCore;

namespace College.API.Application.Services
{
	public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
		public StudentService(IUnitOfWork uow, IMapper mapper)
		{
            _mapper = mapper;
            _uow = uow;
		}

        public async Task CreateStudent(CreateStudentModel student)
        {
            var user = _mapper.Map<UserRecord>(student);
            user.UserType = UserType.Student;
            var entity = _mapper.Map<Student>(student);

            await _uow.UserRepository.AddAsync(user);
            entity.User = user;

            await _uow.StudentRepository.AddAsync(entity);

            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            var students = _uow.StudentRepository.AsQueryable();

            return students.ProjectTo<StudentModel>(_mapper.ConfigurationProvider).AsEnumerable();
        }

        public async Task<IEnumerable<StudentCourseModel>> GetStudentCourses(int id)
        {
            var student = await _uow.StudentRepository.AsQueryable().Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);

            var studentCourses = student.Courses;

            return studentCourses.AsQueryable().ProjectTo<StudentCourseModel>(_mapper.ConfigurationProvider);
        }

        public async Task ApplyCourse(int courseId, int studentId)
        {
            var student = await _uow.StudentRepository.GetAsync(studentId);
            var course = await _uow.CourseRepository.GetAsync(courseId);

            var studentCourse = new StudentCourse()
            {
                Student = student,
                Course = course
            };

            await _uow.StudentCourseRepository.AddAsync(studentCourse);

            await _uow.SaveAsync();
        }
    }
}

