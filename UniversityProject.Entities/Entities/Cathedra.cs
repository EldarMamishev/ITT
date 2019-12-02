using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Cathedra : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Cipher { get; set; }

        public int? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Group> Groups { get; set; }

        public Cathedra() : base()
        {
            Teachers = new List<Teacher>();
            Groups = new List<Group>();
        }
    }
}