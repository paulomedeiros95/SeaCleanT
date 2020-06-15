using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeaCleanSolutions.Areas.Application.Data;
using SeaCleanSolutions.Models;

namespace SeaCleanSolutions.Pages
{
    public class ConfigureCourseModel : PageModel
    {
        private IHostingEnvironment _hostingEnvironment;
        public ConfigureCourseModel(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "PhotoGroup")]
            public string PhotoGroup { get; set; }
        }


        public ActionResult OnPostUpload(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                string folderName = "Uploaded";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (IFormFile item in files)
                {
                    if (item.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        string fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                        var course = new ImageDoc { PhotoName = fileName, PhotoGroup = Input.PhotoGroup };
                        using (var context = new ApplicationDBContext())
                        {
                            context.ImageDocs.Add(course);
                            context.SaveChanges();

                        }
                    }
                }
                
                return this.Content("Success");
            }
            return this.Content("Fail");
        }
    }

}
