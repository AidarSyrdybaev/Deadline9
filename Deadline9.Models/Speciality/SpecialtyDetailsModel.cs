using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class SpecialtyDetailsModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        
        [Display(Name = "Факультет")]
        public string Department { get; set; }
    }
}
