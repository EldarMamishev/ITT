using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Test : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public CompanyUser Author { get; set; }

        public int? SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }        

        public ICollection<Question> Questions { get; set; }
        public ICollection<TestSession> TestSessions { get; set; }

        public Test() : base()
        {
            TestSessions = new List<TestSession>();
            Questions = new List<Question>();
        }
    }
}