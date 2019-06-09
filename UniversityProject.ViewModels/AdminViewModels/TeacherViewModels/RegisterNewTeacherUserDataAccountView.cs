using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.TeacherViewModels
{
    public class RegisterNewTeacherUserDataAccountView
    {
        public List<FacultyRegisterNewTeacherUserDataAccountViewItem> Faculties { get; set; }
        public List<ChairRegisterNewTeacherUserDataAccountViewItem> Chairs { get; set; }
        public List<SubjectRegisterNewTeacherUserDataAccountViewItem> Subjects { get; set; }

        public RegisterNewTeacherUserDataAccountView()
        {
            Faculties = new List<FacultyRegisterNewTeacherUserDataAccountViewItem>();
            Chairs = new List<ChairRegisterNewTeacherUserDataAccountViewItem>();
            Subjects = new List<SubjectRegisterNewTeacherUserDataAccountViewItem>();
        }
    }

    public class FacultyRegisterNewTeacherUserDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ChairRegisterNewTeacherUserDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectRegisterNewTeacherUserDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}