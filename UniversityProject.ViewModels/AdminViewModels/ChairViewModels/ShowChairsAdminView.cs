using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.ChairViewModels
{
    public class ShowChairsAdminView
    {
        public List<ShowChairsAdminViewItem> Chairs { get; set; }

        public ShowChairsAdminView()
        {
            Chairs = new List<ShowChairsAdminViewItem>();
        }
    }

    public class ShowChairsAdminViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cipher { get; set; }
        public string FacultyName { get; set; }
    }
}