﻿using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.TeacherViewModels
{
    public class EditTeacherDataAccountView
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public int FacultyId { get; set; }
        public int ChairId { get; set; }
        public List<SubjectEditTeacherDataAccountViewItem> SelectedSubjects { get; set; }

        public List<FacultyEditTeacherDataAccountViewItem> Faculties { get; set; }
        public List<ChairEditTeacherDataAccountViewItem> Chairs { get; set; }
        public List<SubjectEditTeacherDataAccountViewItem> Subjects { get; set; }

        public EditTeacherDataAccountView()
        {
            Faculties = new List<FacultyEditTeacherDataAccountViewItem>();
            Chairs = new List<ChairEditTeacherDataAccountViewItem>();
            Subjects = new List<SubjectEditTeacherDataAccountViewItem>();
            SelectedSubjects = new List<SubjectEditTeacherDataAccountViewItem>();
        }
    }

    public class FacultyEditTeacherDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ChairEditTeacherDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SubjectEditTeacherDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}