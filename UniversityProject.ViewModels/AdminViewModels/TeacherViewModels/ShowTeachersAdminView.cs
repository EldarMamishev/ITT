using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.TeacherViewModels
{
    public class ShowTeachersAdminView
    {
        public List<TeacherShowTeachersAdminViewItem> Teachers { get; set; }

        public ShowTeachersAdminView()
        {
            Teachers = new List<TeacherShowTeachersAdminViewItem>();
        }
    }

    public class TeacherShowTeachersAdminViewItem
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
