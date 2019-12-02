using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.CathedraViewModels
{
    public class EditCathedraDataAdminView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cipher { get; set; }
        public int FacultyId { get; set; }
        public List<EditCathedraDataAdminViewItem> Faculties { get; set; }

        public EditCathedraDataAdminView()
        {
            Faculties = new List<EditCathedraDataAdminViewItem>();
        }
    }

    public class EditCathedraDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }
}