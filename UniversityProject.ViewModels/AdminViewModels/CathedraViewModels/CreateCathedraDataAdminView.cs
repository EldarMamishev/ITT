using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.CathedraViewModels
{
    public class CreateCathedraDataAdminView
    {
        public List<CreateCathedraDataAdminViewItem> Faculties { get; set; }

        public CreateCathedraDataAdminView()
        {
            Faculties = new List<CreateCathedraDataAdminViewItem>();
        }
    }

    public class CreateCathedraDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }
}