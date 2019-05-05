using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class EditGroupDataAdminView
    {
        public int Id { get; set; }
        public string PrevoiusCipher { get; set; }
        public string CreationYear { get; set; }
        public int CourseNumberType { get; set; }
        public int GroupNumber { get; set; }
        public int ChairId { get; set; }

        public List<int> CourseNumberTypes { get; set; }
        public List<EditGroupDataAdminViewItem> Chairs { get; set; }

        public EditGroupDataAdminView()
        {
            CourseNumberTypes = new List<int>();
            Chairs = new List<EditGroupDataAdminViewItem>();
        }
    }

    public class EditGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string ChairName { get; set; }
    }
}