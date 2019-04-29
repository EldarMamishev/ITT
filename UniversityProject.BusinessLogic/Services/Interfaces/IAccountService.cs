﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UniversityProject.ViewModels.AccountViewModels;

namespace UniversityProject.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterNewStudentUser(RegisterNewStudentUserAccountView viewModel);

        Task<IdentityResult> FinishRegistrationAndConfirmAccount(FinishRegistrationAndConfirmAccountAccountView viewModel);

        Task SignIn(LoginAccountAccountView loginAccountAccountView);

        Task SignOut();

        Task ForgetPassword(ForgetPasswordAccountView viewModel);

        Task ResetPassword(ResetPasswordAccountView viewModel);
    }
}