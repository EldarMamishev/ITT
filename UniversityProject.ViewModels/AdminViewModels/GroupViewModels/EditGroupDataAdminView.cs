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
        public int CathedraId { get; set; }

        public List<int> CourseNumberTypes { get; set; }
        public List<FacultyEditGroupDataAdminViewItem> Faculties { get; set; }
        public List<CathedraEditGroupDataAdminViewItem> Cathedras { get; set; }

        public EditGroupDataAdminView()
        {
            CourseNumberTypes = new List<int>();
            Faculties = new List<FacultyEditGroupDataAdminViewItem>();
            Cathedras = new List<CathedraEditGroupDataAdminViewItem>();
        }
    }

    public class FacultyEditGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }

    public class CathedraEditGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string CathedraName { get; set; }
    }
}