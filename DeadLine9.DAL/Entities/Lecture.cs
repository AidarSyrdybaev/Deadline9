using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Lecture : IEntity
    {
        public int Id { get; set; }

        public Lession Lession { get; set; }

        public int LessionId { get; set; }

        public Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public Group Group { get; set; }

        public int GroupId { get ; set; }


    }
}
