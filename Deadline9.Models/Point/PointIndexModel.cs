using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class PointIndexModel
    {
        public int Id { get; set; }

        public int Semester { get; set; }

        public Student Student { get; set; }

    }
}
