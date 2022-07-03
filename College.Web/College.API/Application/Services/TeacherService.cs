using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.API.Application.Interfaces;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models.Teacher;
using Microsoft.EntityFrameworkCore;

namespace College.API.Application.Services
{
    public class TeacherService : ITeacherService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherModel>> GetAll()
        {
            var teachers = _unitOfWork.TeacherRepository.AsQueryable().Include(x => x.Courses).Include(x => x.DepartmentManager).Include(x => x.EmployeedByDepartment);

            return teachers.ProjectTo<TeacherModel>(_mapper.ConfigurationProvider).AsEnumerable();
        }

        public async Task CreateTeacher(CreateTeacherModel model)
        {
            var user = _mapper.Map<UserRecord>(model);
            var teacher = _mapper.Map<Teacher>(model);

            user.UserType = UserType.Teacher;
            await _unitOfWork.UserRepository.AddAsync(user);

            teacher.User = user;

            await _unitOfWork.TeacherRepository.AddAsync(teacher);

            await _unitOfWork.SaveAsync();
        }

        public async Task AssignTeacherToDepartment(TeacherDepartmentModel model)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetAsync(model.TeacherId);
            var department = await _unitOfWork.DepartmentRepository.GetAsync(model.DepartmentId);

            teacher.EmployeedByDepartment = department;

            await _unitOfWork.SaveAsync();
        }
    }
}

