﻿using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class PointIndexModel
    {
        public int Id { get; set; }
        [Display(Name = "Семестр")]
        public int Semester { get; set; }
        [Display(Name = "Студент")]
        public string StudentName { get; set; }

    }
}
