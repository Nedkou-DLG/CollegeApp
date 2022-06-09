using System;
using AutoMapper;
using College.API.Application.Interfaces;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models;

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

        public async Task<StudentModel> CreateStudent(StudentModel student)
        {
            var entity = _mapper.Map<Student>(student);
            await _uow.StudentRepository.AddAsync(entity);
            await _uow.SaveAsync();
            _uow.StudentRepository.Detach(entity);

            return _mapper.Map<StudentModel>(entity);
        }
    }
}

