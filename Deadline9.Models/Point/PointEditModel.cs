using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class PointEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Семестр обязателен")]
        [Range(1, 10, ErrorMessage = "Недопустимый семестр")]
        [Display(Name = "Наименование")]
        public int Semester { get; set; }
        [Required(ErrorMessage = "Балл обязателен")]
        [Range(1, 100, ErrorMessage = "Недопустимый балл")]
        [Display(Name = "Наименование")]
        public int Ball { get; set; }
        [Required(ErrorMessage = "Наименование обязательно")]
        [Display(Name = "Наименование")]
        public int StudentId { get; set; }
    }
}
