using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeaCleanSolutions.Models
{
    public class Course
    {
        #region Properties
        [Key]
        [Required(ErrorMessage = "Course Name Required")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Field Author Required")]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Field Create To Required")]
        [Display(Name = "Created To")]
        public string CreatedTo { get; set; }

        [Required(ErrorMessage = "Field Group of photos Required")]
        [Display(Name = "Group of photos")]
        public string PhotoGroup { get; set; }

        [Required(ErrorMessage = "Field Questionnarie Name Required")]
        [Display(Name = "Questionnarie Name")]
        public string QuestionnarieName { get; set; }

        [Required(ErrorMessage = "Field Video Url Required")]
        [Display(Name = "Video Url")]
        public string VideoUrl { get; set; }

        #endregion
    }
}
