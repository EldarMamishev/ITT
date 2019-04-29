using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Constants;

namespace UniversityProject.BusinessLogic.Configs
{
    public static class IdentityDependenciesConfig
    {
        public static void InjectApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2);

                options.Cookie.Name = ApplicationConstants.APPLICATION_COOKIE_NAME;

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/";
                options.SlidingExpiration = true;
            });
        }
    }
}