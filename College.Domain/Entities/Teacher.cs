using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{

    [Table("Teachers")]
	public class Teacher : IEntity
	{
        public Teacher()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? EGN { get; set; }

        public int? EmployeedByDepartmentId { get; set; }

        public virtual Department EmployeedByDepartment { get; set; }

        public int? DepartmentManagerId { get; set; }

        public virtual Department DepartmentManager { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

