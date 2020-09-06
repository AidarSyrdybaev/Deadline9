using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class GroupCreateModel
    {
        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Наименование специализации")]
        public int SpecialityId { get; set; }
    }
}
