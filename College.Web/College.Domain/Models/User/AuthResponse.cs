using System;
using College.Domain.Entities;

namespace College.Domain.Models.User
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserType Type { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public AuthResponse(UserRecord user, string token)
        {
            
            this.Username = user.Username;
            this.Type = user.UserType;
            this.Token = token;
            if(user.Teacher != null)
            {
                this.Id = user.Teacher.Id;
                this.Name = user.Teacher.Name;
                this.Email = user.Teacher.Email;
            }else if(user.Student != null)
            {
                this.Id = user.Student.Id;
                this.Name = user.Student.Name;
                this.Email = user.Student.Email;
            }
            else
            {
                this.Id = user.Id;
                this.Name = user.Username;
                this.Email = user.Username + "@admin.com";
            }

        }
    }
}

