using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityProject.BusinessLogic.Mappers;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Providers;
using UniversityProject.BusinessLogic.Providers.Interfaces;
using UniversityProject.BusinessLogic.Services;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Entities.Entities;

namespace UniversityProject.BusinessLogic.Configs
{
    public static class DependenciesConfig
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register Managers
            services.AddTransient<RoleManager<ApplicationRole>>();
            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<SignInManager<ApplicationUser>>();
            #endregion

            #region Providers
            services.AddSingleton<IEmailProvider, EmailProvider>();
            #endregion

            #region Mappers
            services.AddTransient<IAccountMapper, AccountMapper>();
            #endregion

            #region Repositories
            //services.AddTransient<IAccountRepository, AccountRepository>();
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion
        }
    }
}
