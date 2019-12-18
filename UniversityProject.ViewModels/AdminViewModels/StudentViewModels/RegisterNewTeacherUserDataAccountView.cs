using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.StudentViewModels
{
    public class RegisterNewStudentUserDataAccountView
    {
        public List<FacultyRegisterNewStudentUserDataAccountViewItem> Faculties { get; set; }
        public List<CathedraRegisterNewStudentUserDataAccountViewItem> Cathedras { get; set; }
        public List<SubjectRegisterNewStudentUserDataAccountViewItem> Subjects { get; set; }

        public RegisterNewStudentUserDataAccountView()
        {
            Faculties = new List<FacultyRegisterNewStudentUserDataAccountViewItem>();
            Cathedras = new List<CathedraRegisterNewStudentUserDataAccountViewItem>();
            Subjects = new List<SubjectRegisterNewStudentUserDataAccountViewItem>();
        }
    }

    public class FacultyRegisterNewStudentUserDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CathedraRegisterNewStudentUserDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectRegisterNewStudentUserDataAccountViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}