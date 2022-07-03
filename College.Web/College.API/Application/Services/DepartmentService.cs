using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.API.Application.Interfaces;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models.Department;
using College.Domain.Models.Teacher;
using Microsoft.EntityFrameworkCore;

namespace College.API.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateDepartment(CreateDepartmentModel model)
        {
            var department = _mapper.Map<Department>(model);

            await _unitOfWork.DepartmentRepository.AddAsync(department);

            await _unitOfWork.SaveAsync();

        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.AsQueryable().Include(x => x.Manager);

            return departments.ProjectTo<DepartmentModel>(_mapper.ConfigurationProvider).AsEnumerable();
        }

        public async Task<IEnumerable<TeacherModel>> GetTeachersByDepartment(int id)
        {
            var teachers = _unitOfWork.TeacherRepository.AsQueryable().Include(x => x.EmployeedByDepartment).Where(x => x.EmployeedByDepartmentId == id);

            return teachers.ProjectTo<TeacherModel>(_mapper.ConfigurationProvider).AsEnumerable();
        }

        public async Task AssignLeaderToDepartment(TeacherDepartmentModel model)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetAsync(model.TeacherId);
            var department = await _unitOfWork.DepartmentRepository.GetAsync(model.DepartmentId);
            var user = await _unitOfWork.UserRepository.GetAsync(teacher.UserId);

            user.UserType = UserType.DepartmentLeader;

            department.Manager = teacher;

            await _unitOfWork.SaveAsync();
        }
    }
}

