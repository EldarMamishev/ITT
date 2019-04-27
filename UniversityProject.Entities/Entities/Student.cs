using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Entities.Entities
{
    public class Student : ApplicationUser
    {
        [MaxLength(20)]
        public string ParentsPhoneNumber { get; set; }

        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public int CurrentCourseYear { get; set; }
    }
}