using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Entities.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }

        DateTime CreationDateUTC { get; set; }
    }
}