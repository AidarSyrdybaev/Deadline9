using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Point: IEntity
    {
        public int Id { get; set; }

        public int Semester { get; set; }

        public int Ball { get; set }

        public Student Student { get; set; }

        public int StudentId { get; set; }


    }
}
