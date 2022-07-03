using System;
using College.Domain.Models.Teacher;

namespace College.API.Application.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> GetAll();
        Task CreateTeacher(CreateTeacherModel model);
        Task AssignTeacherToDepartment(TeacherDepartmentModel model);
    }
}

