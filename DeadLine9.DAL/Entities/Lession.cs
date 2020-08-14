using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Lession: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
