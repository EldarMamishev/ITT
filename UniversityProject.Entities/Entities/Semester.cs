using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;
using UniversityProject.Entities.Enums;

namespace UniversityProject.Entities.Entities
{
    public class Semester : BaseEntity
    {
        public PartOfEducationYearType PartOfEducationYear { get; set; }
        public DateTime Year { get; set; }

        public int JournalId { get; set; }
        [ForeignKey("JournalId")]
        public Journal Journal { get; set; }

        public ICollection<Statement> Statements { get; set; }

        public Semester() : base()
        {
            Statements = new List<Statement>();
        }
    }
}