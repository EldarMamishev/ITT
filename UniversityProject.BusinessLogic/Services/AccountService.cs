using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UniversityProject.BusinessLogic.Exceptions;
using UniversityProject.BusinessLogic.Providers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Constants;

namespace UniversityProject.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        #region Properties
        //private IAccountMapper _accountMapper;

        private IEmailProvider _emailProvider;

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        #endregion

        #region Constructors
        public AccountService(/*IAccountMapper accountMapper,*/ IEmailProvider emailProvider, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            //_accountMapper = accountMapper;

            _emailProvider = emailProvider;

            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Public Methods
        //public async Task RegisterNewUser(RegisterNewUserView viewModel)
        //{
        //    ApplicationUser user = _accountMapper.MapRegisterViewModelToApplicationUser(viewModel);

        //    if (!(await _userManager.FindByEmailAsync(viewModel.Email) is null) || !(await _userManager.FindByNameAsync(viewModel.UserID) is null))
        //    {
        //        throw new AccountException("Account with such Email or UserID already exists");
        //    }

        //    IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);

        //    if (!result.Succeeded)
        //    {
        //        string responseError = result.GetFirstError();

        //        throw new AccountException(responseError);
        //    }

        //    ApplicationUser userRegistered = await _userManager.FindByNameAsync(viewModel.UserID);

        //    await EmailConfirmation(userRegistered, viewModel.CurrentUrl);

        //    await _userManager.AddToRoleAsync(userRegistered, ApplicationConstants.USER_ROLE);
        //}

        //public async Task<IdentityResult> ConfirmAccount(ConfirmAccountAccountView viewModel)
        //{
        //    var result = new IdentityResult();

        //    if (viewModel.UserId is null || viewModel.Token is null)
        //    {
        //        return result;
        //    }

        //    ApplicationUser user = await _userManager.FindByIdAsync(viewModel.UserId);

        //    if (user is null)
        //    {
        //        return result;
        //    }

        //    if (user.EmailConfirmed)
        //    {
        //        result = IdentityResult.Success;

        //        return result;
        //    }

        //    result = await _userManager.ConfirmEmailAsync(user, viewModel.Token);

        //    return result;
        //}

        //public async Task ResetPassword(ResetPasswordAccountView viewModel)
        //{
        //    ApplicationUser user = await _userManager.FindByIdAsync(viewModel.UserID);

        //    if (user is null)
        //    {
        //        throw new AccountException("User not found.");
        //    }

        //    if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
        //    {
        //        throw new AccountException("Passwords are different.");
        //    }

        //    await _userManager.ResetPasswordAsync(user, viewModel.Token, viewModel.Password);
        //}

        //public async Task ForgetPassword(ForgetPasswordAccountView viewModel)
        //{
        //    ApplicationUser user = await _userManager.FindByNameAsync(viewModel.UserID);

        //    if (user is null)
        //    {
        //        throw new AccountException("User is not found.");
        //    }

        //    if (!user.Email.Equals(viewModel.Email))
        //    {
        //        throw new AccountException("Emails are different.");
        //    }

        //    await CreateForgetPasswordEmail(user, viewModel.CurrentUrl);
        //}

        //public async Task SignIn(LoginAccountAccountView loginAccountAccountView)
        //{
        //    var user = await _userManager.FindByNameAsync(loginAccountAccountView.UserName);

        //    if (user is null)
        //    {
        //        throw new AccountException("Couldn't sign in. UserName or password is incorrect.");
        //    }

        //    if (!user.EmailConfirmed)
        //    {
        //        throw new AccountException("Couldn't sign in. Please, confirm your email address.");
        //    }

        //    SignInResult result = await _signInManager.PasswordSignInAsync(loginAccountAccountView.UserName, loginAccountAccountView.Password, false, false);

        //    if (!result.Succeeded)
        //    {
        //        throw new AccountException("Couldn't sign in. UserName or password is incorrect.");
        //    }
        //}

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        #endregion

        #region Private methods
        private async Task EmailConfirmation(ApplicationUser user, Uri uri)
        {
            string email = user.Email;
            string subject = ApplicationConstants.CONFIRMATION_EMAIL_SUBJECT;

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string tokenHtmlVersion = HttpUtility.UrlEncode(token);

            string linkAddress = $"{uri}Account/ConfirmAccount?userId={user.Id}&token={tokenHtmlVersion}";

            string solutionDir = Directory.GetCurrentDirectory();
            string path = $"{solutionDir}{ApplicationConstants.PATH_TO_CONFIRMATION_EMAIL_TEMPLATE}";

            var body = string.Empty;
            using (var reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{UserName}", user.UserName);
            body = body.Replace("{Name}", user.FirstName);
            body = body.Replace("{Action_url}", linkAddress);

            await _emailProvider.SendMessage(email, subject, body);
        }

        private async Task CreateForgetPasswordEmail(ApplicationUser user, Uri uri)
        {
            string email = user.Email;
            string subject = ApplicationConstants.FORGET_PASSWORD_EMAIL_SUBJECT;

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string tokenHtmlVersion = HttpUtility.UrlEncode(token);

            string linkAddress = $"{uri}Account/ResetPassword?userID={user.Id}&token={tokenHtmlVersion}";

            string solutionDir = Directory.GetCurrentDirectory();
            string path = $"{solutionDir}{ApplicationConstants.PATH_TO_FORGET_PASSWORD_EMAIL_TEMPLATE}";

            var body = string.Empty;
            using (var reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{UserName}", user.UserName);
            body = body.Replace("{Name}", user.FirstName);
            body = body.Replace("{Action_url}", linkAddress);

            await _emailProvider.SendMessage(email, subject, body);
        }
        #endregion
    }
}
