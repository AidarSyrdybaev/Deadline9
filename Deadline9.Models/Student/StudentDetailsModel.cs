using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class StudentDetailsModel
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]

        public string Surname { get; set; }

        [Display(Name = "Имя")]

        public string Name { get; set; }


        [Display(Name = "Отчество")]

        public string LastName { get; set; }


        [Display(Name = "Пол")]

        public bool IsMen { get; set; }

        [Display(Name = "Группа")]

        public string GroupName { get; set; }

        public int GroupId { get; set; }

        public ICollection<Point> Points { get; set; }
    }
}
