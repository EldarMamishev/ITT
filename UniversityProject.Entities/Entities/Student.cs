using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Entities.Entities
{
    public class Student : CompanyUser
    {
        [MaxLength(20)]
        public string ParentsPhoneNumber { get; set; }

        public ICollection<UserTestSession> UserTestSessions { get; set; }

        public Student() : base()
        {
            UserTestSessions = new List<UserTestSession>();
        }
    }
}