using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{
    [Table("Students")]
    public class Student : IEntity
    {

        public Student()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? EGN { get; set; }

        public string? Line { get; set; }

        public string? Email { get; set; }

        public int UserId { get; set; }

        public virtual UserRecord User {get;set;}

        public virtual ICollection<StudentCourse> Courses { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

