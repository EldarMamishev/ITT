using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Entities.Entities
{
    public class Teacher : ApplicationUser
    {
        public TimeSpan WorkExperience { get; set; }
        [MaxLength(20)]
        public string ScienceDegree { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}