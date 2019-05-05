using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class CreateGroupDataAdminView
    {
        public List<int> CourseNumberTypes { get; set; }
        public List<FacultyCreateGroupDataAdminViewItem> Faculties { get; set; }
        public List<ChairCreateGroupDataAdminViewItem> Chairs { get; set; }

        public CreateGroupDataAdminView()
        {
            CourseNumberTypes = new List<int>();
            Faculties = new List<FacultyCreateGroupDataAdminViewItem>();
            Chairs = new List<ChairCreateGroupDataAdminViewItem>();
        }
    }

    public class FacultyCreateGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }

    public class ChairCreateGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string ChairName { get; set; }
    }
}