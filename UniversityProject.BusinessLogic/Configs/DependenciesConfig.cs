using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityProject.BusinessLogic.Fabrics;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Helpers;
using UniversityProject.BusinessLogic.Helpers.Interfaces;
using UniversityProject.BusinessLogic.Mappers;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Providers;
using UniversityProject.BusinessLogic.Providers.Interfaces;
using UniversityProject.BusinessLogic.Services;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories;
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
            services.AddTransient<IFacultyMapper, FacultyMapper>();
            services.AddTransient<IChairMapper, ChairMapper>();
            services.AddTransient<IGroupMapper, GroupMapper>();
            #endregion

            #region Helpers
            services.AddTransient<IDateParseHelper, DateParseHelper>();
            #endregion

            #region Repositories
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IChairRepository, ChairRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAdminService, AdminService>();
            #endregion

            #region Register Fabrics
            services.AddTransient<IMenuItemsFabric, MenuItemsFabric>();
            #endregion
        }
    }
}
