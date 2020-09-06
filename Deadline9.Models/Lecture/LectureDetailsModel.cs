using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class LectureDetailsModel
    {
        public int Id { get; set; }

        public string LessionName { get; set; }

        public int LessionId { get; set; }

        public string TeacherName { get; set; }

        public int TeacherId { get; set; }

        public string GroupName { get; set; }

        public int GroupId { get; set; }
    }
}
