using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SeaCleanSolutions.Areas.Application.Data;
using SeaCleanSolutions.Areas.Identity.Data;
using SeaCleanSolutions.Models;


namespace SeaCleanSolutions.Pages
{
    public class ConfigureCourseModel : PageModel
    {
        private IHostingEnvironment _environment;
        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public ConfigureCourseModel(IHostingEnvironment environment,
            UserManager<SeaCleanSolutionsUser> userManager,
             SignInManager<SeaCleanSolutionsUser> signInManager,
            ILogger<RegisterModel> logger,
               IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _environment = environment;

        }


        [BindProperty]
        public InputModel Input { get; set; }
        public List<IFormFile> files { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "PhotoGroupID")]
            public string PhotoGroupID { get; set; }
        }

        public async Task OnPostAsync(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                string folderName = "Uploaded";
                string webRootPath = _environment.WebRootPath;
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
                        var course = new ImageDoc { PhotoName = fileName, PhotoGroup = Input.PhotoGroupID };
                        using (var context = new ApplicationDBContext())
                        {
                            var checkData = context.ImageDocs
                                .Where(x => x.PhotoName == course.PhotoName && x.PhotoGroup == course.PhotoGroup).ToList().Count();
                            if (checkData == 0)
                            {
                                context.ImageDocs.Add(course);
                                context.SaveChanges();
                            }
                        }

                    }
                }
                ViewData["Message"] = "Files Uploaded Successfuly";
            }

        }

    }
    //    public async Task OnPostAsync(List<IFormFile> files)
    //    {
    //        if (files != null && files.Count > 0)
    //        {
    //            string folderName = "Uploaded";
    //            string webRootPath = _environment.WebRootPath;
    //            string newPath = Path.Combine(webRootPath, folderName);
    //            if (!Directory.Exists(newPath))
    //            {
    //                Directory.CreateDirectory(newPath);
    //            }
    //            foreach (IFormFile item in files)
    //            {
    //                if(item.Length > 0)
    //                {
    //                    string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
    //                    string fullPath = Path.Combine(newPath, fileName);
    //                    using (var stream = new FileStream(fullPath, FileMode.Create))
    //                    {
    //                        item.CopyTo(stream);
    //                    }
    //                    var course = new ImageDoc { PhotoName = fileName, PhotoGroup = PhotoGroupID };
    //                    using (var context = new ApplicationDBContext())
    //                    {
    //                        context.ImageDocs.Add(course);
    //                        context.SaveChanges();

    //                    }

    //                }
    //            }
    //        }           
    //    }

    //    public ActionResult OnPostUpload(List<IFormFile> files)
    //    {
    //        if (files != null && files.Count > 0)
    //        {
    //            string folderName = "Uploaded";
    //            string webRootPath = _environment.WebRootPath;
    //            string newPath = Path.Combine(webRootPath, folderName);
    //            if (!Directory.Exists(newPath))
    //            {
    //                Directory.CreateDirectory(newPath);
    //            }
    //            foreach (IFormFile item in files)
    //            {
    //                if (item.Length > 0)
    //                {
    //                    string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
    //                    string fullPath = Path.Combine(newPath, fileName);
    //                    using (var stream = new FileStream(fullPath, FileMode.Create))
    //                    {
    //                        item.CopyTo(stream);
    //                    }
    //                    ////var course = new ImageDoc { PhotoName = fileName, PhotoGroup = x };
    //                    //using (var context = new ApplicationDBContext())
    //                    //{
    //                    //    context.ImageDocs.Add(course);
    //                    //    context.SaveChanges();

    //                    //}
    //                }
    //            }

    //            return this.Content("Success");
    //        }
    //        return this.Content("Fail");
    //    }
    //}
}

