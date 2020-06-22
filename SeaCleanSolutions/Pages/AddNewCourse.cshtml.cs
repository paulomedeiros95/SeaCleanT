using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SeaCleanSolutions.Areas.Application.Data;
using SeaCleanSolutions.Areas.Identity.Data;
using SeaCleanSolutions.Models;

namespace SeaCleanSolutions.Pages
{
    public class AddNewCourseModel : PageModel
    {

        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;

        private readonly ILogger<AddNewCourseModel> _logger;
        private readonly IEmailSender _emailSender;

        public AddNewCourseModel(
            UserManager<SeaCleanSolutionsUser> userManager,
            SignInManager<SeaCleanSolutionsUser> signInManager,
            ILogger<AddNewCourseModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }



        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<ImageDoc> ImageDocs { get; set; }
        public IEnumerable<QuestionnarieGroupID> Questionnaries { get; set; }


        public class InputModel
        {
            [Required]
            [Display(Name = "Course Name")]
            public string CourseName { get; set; }

            [Required]
            [Display(Name = "Author")]
            public string AuthorName { get; set; }

            [Required]
            [Display(Name = "Created To")]
            public string CreatedTo { get; set; }

            [Display(Name = "Photo Group")]
            public string PhotoGroup { get; set; }

            [Display(Name = "Questionnarie Name")]
            public string QuestionnarieName { get; set; }

            [Display(Name = "Video Url")]
            public string VideoUrl { get; set; }

        }

        public async Task OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var course = new Course { CourseName = Input.CourseName, AuthorName = Input.AuthorName, CreatedTo = Input.CreatedTo,PhotoGroup=Input.PhotoGroup, QuestionnarieName = Input.QuestionnarieName, VideoUrl = Input.VideoUrl };

                using (var context = new ApplicationDBContext())
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
                ViewData["Message"] = "Course created successfuly!";
            }

            // If we got this far, something failed, redisplay form
            ViewData["Message"] = "Something is wrong, please contact your system administrator.";

        }

        public async Task OnGet()
        {
            using (var context = new ApplicationDBContext())
            {
                ImageDocs = await context.ImageDocs.ToListAsync();

                Questionnaries = await context.QuestionnarieGroupIDs.ToListAsync();
            }
        }
    }
}