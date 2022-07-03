using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.API.Application.Interfaces;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models.Course;
using Microsoft.EntityFrameworkCore;

namespace College.API.Application.Services
{
    public class CourseService : ICourseService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseModel>> GetAll()
        {
            var courses = _unitOfWork.CourseRepository.AsQueryable().Include(x => x.Teacher);

            return courses.ProjectTo<CourseModel>(_mapper.ConfigurationProvider).AsEnumerable();
        }

        public async Task CreateCourse(CreateCourseModel model)
        {
            var course = _mapper.Map<Course>(model);

            await _unitOfWork.CourseRepository.AddAsync(course);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CourseModel>> GetTeacherCourses(int id)
        {
            var courses = _unitOfWork.CourseRepository.AsQueryable().Include(x => x.Teacher).Where(x => x.TeacherId == id);

            return courses.ProjectTo<CourseModel>(_mapper.ConfigurationProvider);

        }
    }
}

