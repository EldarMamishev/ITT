using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class EditGroupDataAdminView
    {
        public int Id { get; set; }
        public string CreationYear { get; set; }
        public int CourseNumberType { get; set; }
        public int GroupNumber { get; set; }
        public int FacultyId { get; set; }
        public int ChairId { get; set; }

        public List<int> CourseNumberTypes { get; set; }
        public List<FacultyEditGroupDataAdminViewItem> Faculties { get; set; }
        public List<ChairEditGroupDataAdminViewItem> Chairs { get; set; }

        public EditGroupDataAdminView()
        {
            CourseNumberTypes = new List<int>();
            Faculties = new List<FacultyEditGroupDataAdminViewItem>();
            Chairs = new List<ChairEditGroupDataAdminViewItem>();
        }
    }

    public class FacultyEditGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }

    public class ChairEditGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string ChairName { get; set; }
    }
}