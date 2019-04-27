using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Faculty : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public int StudentsCount { get; set; }
        [MaxLength(30)]
        public string DeanName { get; set; }
        [MaxLength(30)]
        public string ViceDeanName { get; set; }
    }
}
