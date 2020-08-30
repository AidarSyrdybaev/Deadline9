using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class LectureCreateModel
    {
        public int Id { get; set; }

        public int LessionId { get; set; }

        public int TeacherId { get; set; }

        public int GroupId { get; set; }
    }
}
