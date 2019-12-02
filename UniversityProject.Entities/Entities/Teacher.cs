using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Entities.Entities
{
    public class Teacher : ApplicationUser
    {
        public TimeSpan WorkExperience { get; set; }
        [MaxLength(20)]
        public string ScienceDegree { get; set; }

        public int CathedraId { get; set; }
        [ForeignKey("CathedraId")]
        public Cathedra Cathedra { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; }

        public Teacher() : base()
        {
            TeacherSubjects = new List<TeacherSubject>();
        }
    }
}