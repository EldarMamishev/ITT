using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Constants;

namespace UniversityProject.BusinessLogic.Configs
{
    public static class DataBaseInitializer
    {
        public async static Task InitializeDB(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;

            bool adminRoleCheck = await roleManager.RoleExistsAsync(ApplicationConstants.ADMIN_ROLE);
            if (!adminRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.ADMIN_ROLE));
                await CreateAdminUser(userManager);
            }

            bool userRoleCheck = await roleManager.RoleExistsAsync(ApplicationConstants.USER_ROLE);
            if (!userRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.USER_ROLE));
            }

            bool teacherRoleCheck = await roleManager.RoleExistsAsync(ApplicationConstants.TEACHER_ROLE);
            if (!teacherRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.TEACHER_ROLE));
            }

            bool localAdminRoleCheck = await roleManager.RoleExistsAsync(ApplicationConstants.LOCAL_ADMIN_ROLE);
            if (!localAdminRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.LOCAL_ADMIN_ROLE));
            }

            
        }

        private async static Task CreateAdminUser(UserManager<ApplicationUser> userManager)
        {
            var email = "admin@admin.com";
            var password = "Admin123!";

            var user = new ApplicationUser();
            user.UserName = "Admin";
            user.NormalizedEmail = email.ToUpper();
            user.NormalizedUserName = email.ToUpper();
            user.Email = email;
            user.EmailConfirmed = true;
            user.FirstName = "Виктор";
            user.LastName = "Корочанский";
            user.MiddleName = "Валерьевич";
            user.BirthDate = new DateTime(1992,5,6);
            user.AddressLine = "AddressLine avenue, house 56, flat 32";
            user.PhoneNumber = "+380451236957";
            user.EmailConfirmed = true;

            await userManager.CreateAsync(user, password);
            ApplicationUser applicationUser = await userManager.FindByNameAsync(user.UserName);

            await userManager.AddToRoleAsync(applicationUser, ApplicationConstants.ADMIN_ROLE);
        }
    }
}