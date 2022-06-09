using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{
	[Table("Departments")]
	public class Department : IEntity
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string Faculty { get; set; }

        [Required]
        public Teacher Manger { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

