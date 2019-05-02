using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.ChairViewModels
{
    public class EditChairDataAdminView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cipher { get; set; }
        public int FacultyId { get; set; }
        public List<EditChairDataAdminViewItem> Faculties { get; set; }

        public EditChairDataAdminView()
        {
            Faculties = new List<EditChairDataAdminViewItem>();
        }
    }

    public class EditChairDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }
}