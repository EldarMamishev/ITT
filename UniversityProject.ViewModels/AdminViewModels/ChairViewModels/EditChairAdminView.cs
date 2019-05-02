namespace UniversityProject.ViewModels.AdminViewModels.ChairViewModels
{
    public class EditChairAdminView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreviousName { get; set; }
        public string Cipher { get; set; }
        public string PreviousCipher { get; set; }
        public int FacultyId { get; set; }
    }
}