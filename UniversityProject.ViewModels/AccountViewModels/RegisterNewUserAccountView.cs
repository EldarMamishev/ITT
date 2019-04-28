using System;

namespace UniversityProject.ViewModels.AccountViewModels
{
    public class RegisterNewUserAccountView
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string MiddleName { get; set; }
        //public string AddressLineOne { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string PostalCode { get; set; }
        //public string PhoneNumber { get; set; }

        public Uri CurrentUrl { get; set; }
    }
}
