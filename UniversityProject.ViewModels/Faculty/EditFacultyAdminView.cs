namespace UniversityProject.ViewModels.Faculty
{
    public class EditFacultyAdminView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cipher { get; set; }
        public string LastCipher { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public uint StudentsCount { get; set; }
    }
}