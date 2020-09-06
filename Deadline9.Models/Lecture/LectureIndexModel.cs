using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class LectureIndexModel
    {
        public int Id { get; set; }
        [Display(Name = "Урок")]
        public string LessionName { get; set; }
    }
}
