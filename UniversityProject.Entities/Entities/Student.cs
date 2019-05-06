using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Entities.Entities
{
    public class Student : ApplicationUser
    {
        [MaxLength(20)]
        public string ParentsPhoneNumber { get; set; }
        
        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public ICollection<Statement> Statements { get; set; }

        public Student() : base()
        {
            Statements = new List<Statement>();
        }
    }
}