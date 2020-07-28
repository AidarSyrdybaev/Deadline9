using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Department : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Specialty> Specialties {get;set;}
    }
}
