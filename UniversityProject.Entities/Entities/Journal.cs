using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Journal : BaseEntity
    {        
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public ICollection<Semester> Semesters { get; set; }

        public Journal()
        {
            Semesters = new List<Semester>();
        }
    }
}