using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class TestSession : BaseEntity
    {
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        public int? TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        public Test Test { get; set; }

        public ICollection<UserTestSession> UserTestSessions { get; set; }

        public TestSession()
        {
            UserTestSessions = new List<UserTestSession>();
        }
    }
}