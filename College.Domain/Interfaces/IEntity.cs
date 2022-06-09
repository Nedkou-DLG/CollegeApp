using System;
namespace College.Domain.Interfaces
{
	public interface IEntity
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

