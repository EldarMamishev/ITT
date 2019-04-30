using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Subject : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public double CreditsCount { get; set; }
        public uint ControlWorksCount { get; set; }

        public ICollection<SubjectStatement> SubjectStatements { get; set; }
        public ICollection<SemesterSubject> SemesterSubjects { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }

        public Subject() : base()
        {
            TeacherSubjects = new List<TeacherSubject>();
            SemesterSubjects = new List<SemesterSubject>();
            SubjectStatements = new List<SubjectStatement>();
        }
    }
}