using System;
using College.Domain.Models.Teacher;

namespace College.Domain.Models.Department
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public TeacherModel Leader { get; set; }

    }
}

