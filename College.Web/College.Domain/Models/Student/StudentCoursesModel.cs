using System;
using College.Domain.Models.Course;

namespace College.Domain.Models.Student
{
    public class StudentCourseModel
    {
        public int Id { get; set; }
        public CourseModel Course { get; set; }
        public decimal Evaluation { get; set; }
        public int Absences { get; set; }
    }
}

