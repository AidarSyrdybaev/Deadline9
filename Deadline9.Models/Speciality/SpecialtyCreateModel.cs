using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class SpecialtyCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Факультет обязателен")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Факультет обязателен")]
        [Display(Name = "Факультет")]
        public int DepartmentId { get; set; }
    }
}
