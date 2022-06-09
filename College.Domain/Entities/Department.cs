using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using College.Domain.Interfaces;

namespace College.Domain.Entities
{
	[Table("Departments")]
	public class Department : IEntity
	{
        public Department()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Faculty { get; set; }

        public int? ManagerId { get; set; }

        public virtual Teacher Manager { get; set; }

        public virtual ICollection<Teacher> Teachers{ get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

