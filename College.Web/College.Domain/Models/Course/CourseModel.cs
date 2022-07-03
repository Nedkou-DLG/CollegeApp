using System;
using College.Domain.Models.Teacher;

namespace College.Domain.Models.Course
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeacherModel Teacher { get; set; }

    }
}

