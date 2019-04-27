using Microsoft.AspNetCore.Identity;
using System;
using UniversityProject.Entities.Interfaces;

namespace UniversityProject.Entities.Entities
{
    public class ApplicationRole : IdentityRole<int>, IBaseEntity
    {
        #region Properties
        public DateTime CreationDateUTC { get; set; }
        #endregion

        #region Constructors
        public ApplicationRole() : base()
        {
            CreationDateUTC = DateTime.UtcNow;
        }
        public ApplicationRole(string name) : base(name)
        {
            CreationDateUTC = DateTime.UtcNow;
        }
        #endregion
    }
}