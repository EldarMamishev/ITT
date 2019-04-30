using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Course : BaseEntity
    {
        [Range(1, 6)]
        public uint Number { get; set; }

        public int? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

        public ICollection<Group> Groups { get; set; }

        public Course()
        {
            Groups = new List<Group>();
        }
    }
}