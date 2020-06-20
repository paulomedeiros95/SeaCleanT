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
    public class ConfigureQuestionnarieModel : PageModel
    {

        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;


        public ConfigureQuestionnarieModel(
            UserManager<SeaCleanSolutionsUser> userManager,
             SignInManager<SeaCleanSolutionsUser> signInManager,
            ILogger<RegisterModel> logger,
               IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
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

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var questionnarries = new QuestionnarieM
                {
                    QuestionnarieID = Input.QuestionnarieID,
                    QuestionNumber = Input.QuestionNumber,
                    Question = Input.Question,
                    AnswersOptions = Input.AnswersOptions,
                    Answer = Input.Answer
                };

                using(var context = new ApplicationDBContext())
                {
                    context.Questionnaries.Add(questionnarries);
                    context.SaveChanges();
                }
            }
            ViewData["Message"] = "Questionnaries saved successfuly!";
        }

    }
}
