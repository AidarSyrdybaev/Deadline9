using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deadline9.Models
{
    public class LectureCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Урок обязателен")]
        [Display(Name = "Урок")]
        public int LessionId { get; set; }
        [Required(ErrorMessage ="Учитель обязателен")]
        [Display(Name = "Учитель")]
        public int TeacherId { get; set; }
        [Required(ErrorMessage ="Группа обязательна")]
        [Display(Name = "Группа")]
        public int GroupId { get; set; }
    }
}
