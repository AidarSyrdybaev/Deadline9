﻿using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class StudentIndexModel
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]

        public string Surname { get; set; }
        
        [Display(Name = "Имя")]

        public string Name { get; set; }

        [Display(Name = "Отчество")]

        public string LastName { get; set; }

    }
}
