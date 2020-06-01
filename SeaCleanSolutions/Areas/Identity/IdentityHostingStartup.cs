using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeaCleanSolutions.Areas.Identity.Data;
using SeaCleanSolutions.Models;

[assembly: HostingStartup(typeof(SeaCleanSolutions.Areas.Identity.IdentityHostingStartup))]
namespace SeaCleanSolutions.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IndentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IndentityContextConnection")));

                services.AddDefaultIdentity<SeaCleanSolutionsUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<IndentityContext>();
            });
        }
    }
}