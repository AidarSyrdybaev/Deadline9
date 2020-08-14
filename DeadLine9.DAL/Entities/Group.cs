using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Group: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpecialityId { get; set; }

        public Specialty Specialty { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
