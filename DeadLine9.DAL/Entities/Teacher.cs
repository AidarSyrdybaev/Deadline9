using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Teacher: IEntity
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string TelephoneNumber { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

    }
}
