using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class StudentStatement : BaseEntity
    {
        public int StatementId { get; set; }
        [ForeignKey("StatementId")]
        public Statement Statement { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}