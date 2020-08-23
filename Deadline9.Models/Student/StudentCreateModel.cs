using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class StudentCreateModel
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public bool IsMen { get; set; }

        public int GroupId { get; set; }

    }
}
