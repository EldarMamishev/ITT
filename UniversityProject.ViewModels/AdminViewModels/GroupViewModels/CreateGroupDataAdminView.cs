using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class CreateGroupDataAdminView
    {
        public List<int> CourseNumberTypes { get; set; }
        public List<FacultyCreateGroupDataAdminViewItem> Faculties { get; set; }
        public List<CathedraCreateGroupDataAdminViewItem> Cathedras { get; set; }

        public CreateGroupDataAdminView()
        {
            CourseNumberTypes = new List<int>();
            Faculties = new List<FacultyCreateGroupDataAdminViewItem>();
            Cathedras = new List<CathedraCreateGroupDataAdminViewItem>();
        }
    }

    public class FacultyCreateGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }

    public class CathedraCreateGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string CathedraName { get; set; }
    }
}