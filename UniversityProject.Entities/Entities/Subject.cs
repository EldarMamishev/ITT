using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Subject : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Statement> Statements { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }

        public Subject() : base()
        {
            TeacherSubjects = new List<TeacherSubject>();
            Statements = new List<Statement>();
        }
    }
}