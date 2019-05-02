using System.Collections.Generic;

namespace UniversityProject.ViewModels.Faculty
{
    public class ShowFacultiesAdminView
    {
        public List<ShowFacultiesAdminViewItem> Faculties { get; set; }

        public ShowFacultiesAdminView()
        {
            Faculties = new List<ShowFacultiesAdminViewItem>();
        }
    }

    public class ShowFacultiesAdminViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cipher { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public uint StudentsCount { get; set; }
    }
}