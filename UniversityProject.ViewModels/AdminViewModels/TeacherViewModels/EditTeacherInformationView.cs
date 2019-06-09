namespace UniversityProject.ViewModels.AdminViewModels.TeacherViewModels
{
    public class EditTeacherInformationView
    {
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public int FacultyId { get; set; }
        public int ChairId { get; set; }
    }
}