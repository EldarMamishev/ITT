using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Statement : BaseEntity
    {
        public decimal Mark { get; set; }

        public int JournalId { get; set; }
        [ForeignKey("JournalId")]
        public Journal Journal { get; set; }

        public ICollection<SubjectStatement> SubjectStatements { get; set; }

        public Statement() : base()
        {
            SubjectStatements = new List<SubjectStatement>();
        }
    }
}