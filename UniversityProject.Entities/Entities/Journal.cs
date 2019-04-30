using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Journal : BaseEntity
    {
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }
        
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public ICollection<Statement> Statements { get; set; }

        public Journal()
        {
            Statements = new List<Statement>();
        }
    }
}