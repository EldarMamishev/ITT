using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Constants;

namespace UniversityProject.BusinessLogic.Configs
{
    public static class DataBaseInitializer
    {
        public static void InitializeDB(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;

            var adminRoleCheck = roleManager.RoleExistsAsync(ApplicationConstants.ADMIN_ROLE).Result;
            if (!adminRoleCheck)
            {
                roleResult = roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.ADMIN_ROLE)).Result;
                CreateAdminUser(userManager);
            }

            var userRoleCheck = roleManager.RoleExistsAsync(ApplicationConstants.USER_ROLE).Result;
            if (!userRoleCheck)
            {
                roleResult = roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.USER_ROLE)).Result;
            }

            var teacherRoleCheck = roleManager.RoleExistsAsync(ApplicationConstants.TEACHER_ROLE).Result;
            if (!teacherRoleCheck)
            {
                roleResult = roleManager.CreateAsync(new ApplicationRole(ApplicationConstants.TEACHER_ROLE)).Result;
            }
        }

        private static void CreateAdminUser(UserManager<ApplicationUser> userManager)
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
            user.Country = "Украина";
            user.City = "Харьков";
            user.PhoneNumber = "+380451236957";
            user.EmailConfirmed = true;

            userManager.CreateAsync(user, password).GetAwaiter().GetResult();
            var applicationUser = userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();

            userManager.AddToRoleAsync(applicationUser, ApplicationConstants.ADMIN_ROLE).GetAwaiter().GetResult();
        }
    }
}