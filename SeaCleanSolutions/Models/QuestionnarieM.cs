using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeaCleanSolutions.Models
{
    public class QuestionnarieM
    {

        [Required]
        public string QuestionnarieID { get; set; }

        [Required]
        public int QuestionNumber { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string AnswersOptions { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
