﻿using System;

namespace UniversityProject.ViewModels.AdminViewModels.TeacherViewModels
{
    public class RegisterNewTeacherUserAccountView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public int FacultyId { get; set; }
        public int ChairId { get; set; }
        public int SubjectId { get; set; }
        //public TimeSpan WorkExperience { get; set; }
        //public string ScienceDegree { get; set; }
    }
}