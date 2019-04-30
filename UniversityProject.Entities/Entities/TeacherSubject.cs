using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class TeacherSubject : BaseEntity
    {
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}