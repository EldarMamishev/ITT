using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UniversityProject.BusinessLogic.Extentions;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Providers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AccountViewModels;

namespace UniversityProject.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        #region Properties
        private ICompanyRepository _cathedraRepository;

        private IAccountMapper _accountMapper;

        private IEmailProvider _emailProvider;

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        #endregion

        #region Constructors
        public AccountService(
            ICompanyRepository cathedraRepository, 
            IAccountMapper accountMapper, 
            IEmailProvider emailProvider, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _cathedraRepository = cathedraRepository;

            _accountMapper = accountMapper;

            _emailProvider = emailProvider;

            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Public Methods     
        public async Task LoadFinishRegistrationData(FinishRegistrationAccountView viewModel)
        {
            var cathedras = await _cathedraRepository.GetAll() as List<Company>;

            foreach (Company cathedra in cathedras)
            {
                var cathedraViewItem = new CathedraFinishRegistrationAccountViewItem();

                cathedraViewItem.Id = cathedra.Id;
                cathedraViewItem.CathedraName = cathedra.Name;

                viewModel.Cathedras.Add(cathedraViewItem);
            }
            
        }

        public async Task<IdentityResult> FinishRegistrationAndConfirmAccount(FinishRegistrationAndConfirmAccountAccountView viewModel)
        {
            var result = new IdentityResult();

            if (viewModel.UserId is null || viewModel.Token is null)
            {
                throw new AccountException("Error finishing registration.");
            }

            ApplicationUser user = await _userManager.FindByIdAsync(viewModel.UserId);

            if (user is null)
            {
                throw new AccountException("User not found.");
            }

            if (user.EmailConfirmed)
            {
                result = IdentityResult.Success;

                return result;
            }

            _accountMapper.MapFinishRegistrationAndConfirmAccountToApplicationUser(viewModel, user as Student);

            IdentityResult updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                throw new AccountException("Error updating user.");
            }

            result = await _userManager.ConfirmEmailAsync(user, viewModel.Token);
            
            return result;
        }

        public async Task ResetPassword(ResetPasswordAccountView viewModel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(viewModel.UserId);

            if (user is null)
            {
                throw new AccountException("User not found.");
            }

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AccountException("Passwords are different.");
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, viewModel.Token, viewModel.Password);
        }

        public async Task ForgetPassword(ForgetPasswordAccountView viewModel)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user is null)
            {
                throw new AccountException("User is not found.");
            }

            if (!user.Email.Equals(viewModel.Email))
            {
                throw new AccountException("Emails are different.");
            }

            await CreateForgetPasswordEmail(user, viewModel.CurrentUrl);
        }

        public async Task SignIn(LoginAccountAccountView loginAccountAccountView)
        {
            var user = await _userManager.FindByEmailAsync(loginAccountAccountView.Email);

            if (user is null)
            {
                throw new AccountException("Couldn't sign in. UserName or password is incorrect.");
            }

            if (!user.EmailConfirmed)
            {
                throw new AccountException("Couldn't sign in. Please, confirm your email address.");
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, loginAccountAccountView.Password, false, false);

            if (!result.Succeeded)
            {
                throw new AccountException("Couldn't sign in. UserName or password is incorrect.");
            }
        }

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

            string linkAddress = $"{uri}Account/FinishRegistration?userId={user.Id}&token={tokenHtmlVersion}&username={user.UserName}";

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

            string linkAddress = $"{uri}Account/ResetPassword?userId={user.Id}&token={tokenHtmlVersion}";

            string solutionDir = Directory.GetCurrentDirectory();
            string path = $"{solutionDir}{ApplicationConstants.PATH_TO_FORGET_PASSWORD_EMAIL_TEMPLATE}";

            var body = string.Empty;
            using (var reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{Name}", user.FirstName);
            body = body.Replace("{Action_url}", linkAddress);

            await _emailProvider.SendMessage(email, subject, body);
        }
        #endregion
    }
}
