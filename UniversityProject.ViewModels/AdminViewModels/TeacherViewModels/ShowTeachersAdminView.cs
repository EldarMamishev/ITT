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
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ChairName { get; set; }
        public string SubjectName { get; set; }
    }
}
