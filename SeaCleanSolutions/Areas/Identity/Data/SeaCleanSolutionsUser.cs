﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SeaCleanSolutions.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the SeaCleanSolutionsUser class
    public class SeaCleanSolutionsUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string Positions { get; set; }
    }
}
