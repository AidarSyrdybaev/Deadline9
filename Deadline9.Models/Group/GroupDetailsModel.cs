﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class GroupDetailsModel
    {
        public int Id { get; set; }
       
        [Display(Name = "Наименование")]
        public string Name { get; set; }
       
        [Display(Name = "Наименование специализации")]
        public string SpecialityName { get; set; }
    }
}
