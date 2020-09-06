using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class PointCreateModel
    {
        [Required(ErrorMessage = "Семестр обязателен")]
        [Range(1, 10, ErrorMessage = "Недопустимый семестр")]
        [Display(Name = "Семестр")]
        public int Semester { get; set; }
        [Required(ErrorMessage = "Балл обязателен")]
        [Range(1, 100, ErrorMessage = "Недопустимый балл")]
        [Display(Name = "Балл")]
        public int Ball { get; set; }
        [Required(ErrorMessage = "Наименование обязательно")]
        [Display(Name = "Студент")]
        public int StudentId { get; set; }
    }
}
