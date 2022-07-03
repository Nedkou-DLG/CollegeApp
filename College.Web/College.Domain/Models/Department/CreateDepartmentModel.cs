using System;
namespace College.Domain.Models.Department
{
    public class CreateDepartmentModel
    {
        public string Name { get; set; }

        public string Faculty { get; set; }

        public int? ManagerId { get; set; }
    }
}

