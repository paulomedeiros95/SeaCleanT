using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SeaCleanSolutions.Areas.Application.Data;
using SeaCleanSolutions.Areas.Identity.Data;
using SeaCleanSolutions.Models;

namespace SeaCleanSolutions.Pages
{
    public class CourseListModel : PageModel
    {
        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;
        private readonly ILogger<CourseListModel> _logger;


        public CourseListModel(UserManager<SeaCleanSolutionsUser> userManager,
            SignInManager<SeaCleanSolutionsUser> signInManager,
            ILogger<CourseListModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public IEnumerable<Course> Courses { get; set; }


        public async Task OnGet()
        {
            using (var context = new ApplicationDBContext())
            {
                Courses = await context.Courses.ToListAsync();
            }
        }
    }
}