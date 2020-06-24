using System;
using System.Collections.Generic;
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
    public class CourseModel : PageModel
    {

        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;

        private readonly ILogger<CourseModel> _logger;
        private readonly IEmailSender _emailSender;

        public CourseModel(
            UserManager<SeaCleanSolutionsUser> userManager,
            SignInManager<SeaCleanSolutionsUser> signInManager,
            ILogger<CourseModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }


        [BindProperty]
        public IEnumerable<ImageDoc> ImageDocs { get; set; }
        public IEnumerable<QuestionnarieM> QuestionarieModel { get; set; }
        public IEnumerable<Course> Courses { get; set; }


        public async Task OnGet(string course)
        {
            using (var context = new ApplicationDBContext())
            {
                ImageDocs = await context.ImageDocs.Where(x => x.PhotoGroup == course).ToListAsync();

                QuestionarieModel = await context.Questionnaries.Where(x => x.QuestionnarieID == course).ToListAsync();//QuestionnarieID é o identificador

                Courses = await context.Courses.Where(x => x.CourseName == course).ToListAsync();  //CourseName é o identificador
            }
        }
    }
}