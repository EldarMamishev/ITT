using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Entities.Entities
{
    public class Teacher : CompanyUser
    {
        public TimeSpan WorkExperience { get; set; }
        [MaxLength(20)]
        public string ScienceDegree { get; set; }

        public ICollection<TestSession> TestSessions { get; set; }

        public Teacher() : base()
        {
            TestSessions = new List<TestSession>();
        }
    }
}