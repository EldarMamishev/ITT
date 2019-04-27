using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Group : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Cipher { get; set; }
        public int FacultyId { get; set; }
    }
}