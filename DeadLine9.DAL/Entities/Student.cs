using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Student: IEntity   
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public bool IsMen { get; set; } 

        public Group Group { get; set; }

        public int GroupId { get; set; }

        public ICollection<Point> Points { get; set; }
    }
}
