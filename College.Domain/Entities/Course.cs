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
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public Teacher Teacher { get; set; }

        public virtual ICollection<StudentCourse> Students { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

