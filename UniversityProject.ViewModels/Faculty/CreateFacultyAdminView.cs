using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityProject.ViewModels.Faculty
{
    public class CreateFacultyAdminView
    {
        public string Name { get; set; }
        public string Cipher { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public uint StudentsCount { get; set; }
    }
}