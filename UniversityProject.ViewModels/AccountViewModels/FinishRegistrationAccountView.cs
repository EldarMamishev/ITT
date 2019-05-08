using System.Collections.Generic;

namespace UniversityProject.ViewModels.AccountViewModels
{
    public class FinishRegistrationAccountView
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }

        public List<FacultyFinishRegistrationAccountViewItem> Faculties { get; set; }
        public List<ChairFinishRegistrationAccountViewItem> Chairs { get; set; }
        public List<GroupFinishRegistrationAccountViewItem> Groups { get; set; }

        public FinishRegistrationAccountView()
        {
            Faculties = new List<FacultyFinishRegistrationAccountViewItem>();
            Chairs = new List<ChairFinishRegistrationAccountViewItem>();
            Groups = new List<GroupFinishRegistrationAccountViewItem>();
        }
    }

    public class FacultyFinishRegistrationAccountViewItem
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
    }

    public class ChairFinishRegistrationAccountViewItem
    {
        public int Id { get; set; }
        public string ChairName { get; set; }
    }

    public class GroupFinishRegistrationAccountViewItem
    {
        public int Id { get; set; }
        public string Cipher { get; set; }
    }
}