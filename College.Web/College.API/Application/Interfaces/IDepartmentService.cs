using System;
using College.Domain.Models.Department;
using College.Domain.Models.Teacher;

namespace College.API.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateDepartment(CreateDepartmentModel model);
        Task<IEnumerable<DepartmentModel>> GetAllDepartments();
        Task<IEnumerable<TeacherModel>> GetTeachersByDepartment(int id);
        Task AssignLeaderToDepartment(TeacherDepartmentModel model);
    }
}

