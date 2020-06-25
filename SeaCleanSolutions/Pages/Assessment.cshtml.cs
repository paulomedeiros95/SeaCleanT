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
    public class AssessmentModel : PageModel
    {
        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;

        private readonly ILogger<AssessmentModel> _logger;
        private readonly IEmailSender _emailSender;


        public AssessmentModel(
           UserManager<SeaCleanSolutionsUser> userManager,
           SignInManager<SeaCleanSolutionsUser> signInManager,
           ILogger<AssessmentModel> logger,
           IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public IEnumerable<QuestionnarieM> QuestionarieModel { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        //public Dictionary<int, string> options { get; set; }
        public List<Tuple<int, string>> options { get; set; }

        public async Task OnGet(string qID)
        {
            using (var context = new ApplicationDBContext())
            {
                Courses = await context.Courses.Where(x => x.CourseName == qID).ToListAsync();
                QuestionarieModel = await context.Questionnaries.Where(x => x.QuestionnarieID == qID).ToListAsync();//QuestionnarieID é o identificador
            }

            var OptionsList = new List<Tuple<int, string>>
            {
                //Tuple.Create(item.QuestionNumber, alternativesItem)
            };

            foreach (var item in QuestionarieModel)
            {
                var stringToParse = item.AnswersOptions;
                string[] alternatives = stringToParse.Split(';');

                foreach (var alternativesItem in alternatives)
                {
                    //Tuple.Create(item.QuestionNumber, alternativesItem);
                    OptionsList.Add(new Tuple<int, string>(item.QuestionNumber, alternativesItem));
                }
                options = OptionsList;
            }
        }
    }
}