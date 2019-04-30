using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class SubjectStatement : BaseEntity
    {
        public int StatementId { get; set; }
        [ForeignKey("StatementId")]
        public Statement Statement { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}