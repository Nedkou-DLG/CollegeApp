using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{

    [Table("Teachers")]
	public class Teacher : IEntity
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string EGN { get; set; }

        [Required]
        public Department EmployeedByDepatment { get; set; }

        public Department DepartmentManager { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

