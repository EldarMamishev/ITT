using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Subject : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public double CreditsCount { get; set; }
    }
}