using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.ChairViewModels
{
    public class CreateChairDataAdminView
    {
        public List<CreateChairDataAdminViewItem> Faculties { get; set; }

        public CreateChairDataAdminView()
        {
            Faculties = new List<CreateChairDataAdminViewItem>();
        }
    }

    public class CreateChairDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }
}