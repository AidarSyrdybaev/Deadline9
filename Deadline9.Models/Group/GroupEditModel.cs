using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class GroupEditModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Наименование обязательно!")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Наименование специализации обязательно!")]
        [Display(Name = "Наименование специализации")]
        public int SpecialityId { get; set; }
    }
}