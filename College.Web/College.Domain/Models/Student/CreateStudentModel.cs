using System;
namespace College.Domain.Models.Student
{
    public class CreateStudentModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string EGN { get; set; }

        public string Line { get; set; }

        public string Email { get; set; }
    }
}

