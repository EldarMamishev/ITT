using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;
using UniversityProject.Entities.Enums;

namespace UniversityProject.Entities.Entities
{
    public class UserTestSession : BaseEntity
    {
        [MaxLength(30)]
        public DateTime Date { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        
        public int? TestSessionId { get; set; }
        [ForeignKey("TestSessionId")]
        public TestSession TestSession { get; set; }      

        public ICollection<ResultNote> ResultNotes { get; set; }

        public UserTestSession()
        {
            ResultNotes = new List<ResultNote>();
        }
    }
}