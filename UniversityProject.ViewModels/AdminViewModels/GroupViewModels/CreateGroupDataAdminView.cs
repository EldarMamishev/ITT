using System.Collections.Generic;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class CreateGroupDataAdminView
    {
        public List<int> CourseNumberTypes { get; set; }
        public List<CreateGroupDataAdminViewItem> Chairs { get; set; }

        public CreateGroupDataAdminView()
        {
            CourseNumberTypes = new List<int>();
            Chairs = new List<CreateGroupDataAdminViewItem>();
        }
    }

    public class CreateGroupDataAdminViewItem
    {
        public int Id { get; set; }
        public string ChairName { get; set; }
    }
}