using System;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{
    public class UserRecord : IEntity
    {
        public UserRecord()
        {
            this.CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual Student? Student { get; set; }
    }
}

