using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SeaCleanSolutions.Pages
{
    public class MainPainelModel : PageModel
    {
        private readonly ILogger<MainPainelModel> _logger;

        public MainPainelModel(ILogger<MainPainelModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
