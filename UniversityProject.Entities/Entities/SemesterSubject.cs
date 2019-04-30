using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class SemesterSubject : BaseEntity
    {
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
