using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Interfaces;

namespace UniversityProject.Entities.Entities
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser<int>, IBaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        [MaxLength(20)]
        public string City { get; set; }
        [MaxLength(50)]
        public string AddressLine { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDateAuth { get; set; }
        public DateTime CreationDateUTC { get; set; }

        public ApplicationUser()
        {
            CreationDateUTC = DateTime.UtcNow;
        }
    }
}