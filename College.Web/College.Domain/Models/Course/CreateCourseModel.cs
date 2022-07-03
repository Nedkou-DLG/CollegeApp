using System;
namespace College.Domain.Models.Course
{
    public class CreateCourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }
}

