using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class StudentEditModel
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public bool IsMen { get; set; }

        public int GroupId { get; set; }

        public ICollection<Point> Points { get; set; }
    }
}
