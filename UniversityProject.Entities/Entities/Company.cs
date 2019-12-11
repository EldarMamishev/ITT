using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Company : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<CompanyUser> CompanyUsers { get; set; }

        public Company() : base()
        {
            CompanyUsers = new List<CompanyUser>();
        }
    }
}