using System;
namespace College.Domain.Models.Teacher
{
    public class CreateTeacherModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string? Name { get; set; }

        public string? EGN { get; set; }

        public string? Email { get; set; }
    }
}

