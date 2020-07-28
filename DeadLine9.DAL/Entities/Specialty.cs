using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Specialty: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
