using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class TeacherEditModel
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

        [Required(ErrorMessage = "Адресс обязателен")]
        [Display(Name = "Адресс")]

        public string Adress { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен")]
        [Display(Name = "Номер телефона")]

        public string TelephoneNumber { get; set; }
    }
}
