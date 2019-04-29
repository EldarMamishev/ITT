using System;

namespace UniversityProject.ViewModels.AccountViewModels
{
    public class RegisterNewStudentUserAccountView
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Uri CurrentUrl { get; set; }
    }
}