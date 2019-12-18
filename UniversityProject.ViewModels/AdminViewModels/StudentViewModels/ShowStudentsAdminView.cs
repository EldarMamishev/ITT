using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.StudentViewModels
{
    public class ShowStudentsAdminView
    {
        public List<StudentShowStudentsAdminViewItem> Students { get; set; }

        public ShowStudentsAdminView()
        {
            Students = new List<StudentShowStudentsAdminViewItem>();
        }
    }

    public class StudentShowStudentsAdminViewItem
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
