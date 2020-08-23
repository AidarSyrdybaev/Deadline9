﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class DepartmentCreateModel
    {   
        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
