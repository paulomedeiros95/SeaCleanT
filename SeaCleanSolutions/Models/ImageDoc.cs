using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeaCleanSolutions.Models
{
    public class ImageDoc
    {
     
        public string PhotoName { get; set; }
              
        public string PhotoGroup { get; set; }
    }
}
