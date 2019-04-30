using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AccountViewModels;

namespace UniversityProject.WEB.Controllers
{
    public class AccountController : Controller
    {
        #region Properties & Variables
        private readonly IAccountService _accountService;
        #endregion

        #region Constructors
        public AccountController(IAccountService accountService) : base()
        {
            _accountService = accountService;
        }
        #endregion

        #region Public methods
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginAccountAccountView loginAccountAccountView)
        {
            try
            {
                await _accountService.SignIn(loginAccountAccountView);

                if (string.IsNullOrWhiteSpace(loginAccountAccountView.ReturnUrl))
                {
                    return Redirect("~/");
                }

                return Redirect($"~{loginAccountAccountView.ReturnUrl}");
            }
            catch (AccountException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(returnUrl as object);
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordAccountView forgetPasswordView)
        {
            try
            {
                var url = new Uri($"{Request.Scheme}://{Request.Host}");
                forgetPasswordView.CurrentUrl = url;
                await _accountService.ForgetPassword(forgetPasswordView);
                return RedirectToAction("LogIn", "Account");
            }
            catch (AccountException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string userID, string token)
        {
            return View((userID, token));
        }

        [HttpPost]
        public async Task<IActionResult> TryResetPassword(ResetPasswordAccountView viewModel)
        {
            try
            {
                await _accountService.ResetPassword(viewModel);
                return RedirectToAction("LogIn", "Account");
            }
            catch (AccountException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewStudentUser([FromForm]RegisterNewStudentUserAccountView registerNewUserView)
        {
            try
            {
                var url = new Uri($"{Request.Scheme}://{Request.Host}");
                registerNewUserView.CurrentUrl = url;
                await _accountService.RegisterNewStudentUser(registerNewUserView);

                return RedirectToAction("LogIn", "Account");
            }
            catch (AccountException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult FinishRegistration(FinishRegistrationAccountView viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FinishRegistrationAndConfirmAccount([FromForm]FinishRegistrationAndConfirmAccountAccountView viewModel)
        {
            IdentityResult result = await _accountService.FinishRegistrationAndConfirmAccount(viewModel);

            return RedirectToAction("LogIn", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.SignOut();
            return RedirectToAction("LogIn", "Account");
        }
        #endregion
    }
}