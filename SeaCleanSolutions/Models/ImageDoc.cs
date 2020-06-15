using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeaCleanSolutions.Models
{
    public class ImageDoc
    {
        [Key]
        public string PhotoName { get; set; }

        public string PhotoGroup { get; set; }
    }
}
