using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class PointEditModel
    {
        public int Id { get; set; }

        public int Semester { get; set; }

        public int Ball { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }
    }
}
