using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.CathedraViewModels
{
    public class ShowCathedrasAdminView
    {
        public List<ShowCathedrasAdminViewItem> Cathedras { get; set; }

        public ShowCathedrasAdminView()
        {
            Cathedras = new List<ShowCathedrasAdminViewItem>();
        }
    }

    public class ShowCathedrasAdminViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cipher { get; set; }
        public string FacultyName { get; set; }
    }
}