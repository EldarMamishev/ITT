using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityProject.ViewModels.AdminViewModels.GroupViewModels
{
    public class EditGroupAdminView
    {
        public int Id { get; set; }
        public string PrevoiusCipher { get; set; }
        public string CreationYear { get; set; }
        public int CourseNumberTypeId { get; set; }
        public int GroupNumber { get; set; }
        public int ChairId { get; set; }
    }
}