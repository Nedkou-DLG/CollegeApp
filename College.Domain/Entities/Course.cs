using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{
    [Table("Courses")]
	public class Course : IEntity
	{
        public Course()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<StudentCourse> Students { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

