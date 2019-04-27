using System;
using System.ComponentModel.DataAnnotations;
using UniversityProject.Entities.Interfaces;

namespace UniversityProject.Entities.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public DateTime CreationDateUTC { get; set; }
        #endregion

        #region Constructors
        public BaseEntity()
        {
            CreationDateUTC = DateTime.UtcNow;
        }
        #endregion
    }
}