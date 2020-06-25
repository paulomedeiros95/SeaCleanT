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
    public class PreAssessmentModel : PageModel
    {
        private readonly SignInManager<SeaCleanSolutionsUser> _signInManager;
        private readonly UserManager<SeaCleanSolutionsUser> _userManager;
        private readonly ILogger<PreAssessmentModel> _logger;
        private readonly IEmailSender _emailSender;


        public PreAssessmentModel(
            UserManager<SeaCleanSolutionsUser> userManager,
            SignInManager<SeaCleanSolutionsUser> signInManager,
            ILogger<PreAssessmentModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }



        [BindProperty]
        public IEnumerable<QuestionnarieM> QuestionarieModel { get; set; }

        
        public async Task OnGet(string qID)
        {
            using (var context = new ApplicationDBContext())
            {
                QuestionarieModel = await context.Questionnaries.Where(x => x.QuestionnarieID == qID).ToListAsync();//QuestionnarieID é o identificador
            }
        }
    }
}