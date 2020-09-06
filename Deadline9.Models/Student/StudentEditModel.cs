using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class StudentEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [Display(Name = "Фамилия")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Имя обязательно")]
        [Display(Name = "Имя")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Отчество обязательно")]
        [Display(Name = "Отчество")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Пол обязателен")]
        [Display(Name = "Пол")]

        public bool IsMen { get; set; }
        [Required(ErrorMessage = "Группа обязательна")]
        [Display(Name = "Группа")]

        public int GroupId { get; set; }

        public ICollection<Point> Points { get; set; }
    }
}
