using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Faculty : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Cipher { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public uint StudentsCount { get; set; }
        //[MaxLength(30)]
        //public string DeanName { get; set; }
        //[MaxLength(30)]
        //public string ViceDeanName { get; set; }

        public ICollection<Chair> Chairs { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Faculty() : base()
        {
            Courses = new List<Course>();
            Chairs = new List<Chair>();
        }
    }
}