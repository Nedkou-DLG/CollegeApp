using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{
    [Table("StudentCourse")]
	public class StudentCourse : IEntity
	{
        public StudentCourse()
        {
            this.CreatedDate = DateTime.Now;
        }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public decimal? Evalutation { get; set; }

        public int? Absences { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

