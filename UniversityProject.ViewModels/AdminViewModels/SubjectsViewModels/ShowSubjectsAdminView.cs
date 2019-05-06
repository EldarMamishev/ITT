using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels
{
    public class ShowSubjectsAdminView
    {
        public List<ShowSubjectsAdminViewItem> Subjects { get; set; }

        public ShowSubjectsAdminView()
        {
            Subjects = new List<ShowSubjectsAdminViewItem>();
        }
    }

    public class ShowSubjectsAdminViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}