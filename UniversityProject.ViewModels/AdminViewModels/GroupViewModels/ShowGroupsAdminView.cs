using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class ShowGroupsAdminView
    {
        public List<ShowGroupsAdminViewItem> Groups { get; set; }

        public ShowGroupsAdminView()
        {
            Groups = new List<ShowGroupsAdminViewItem>();
        }
    }

    public class ShowGroupsAdminViewItem
    {
        public int Id { get; set; }
        public string Cipher { get; set; }
        public string FacultyName { get; set; }
        public string ChairName { get; set; }
        public int CountOfStudents { get; set; }
    }
}