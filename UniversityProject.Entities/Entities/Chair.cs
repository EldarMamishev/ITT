﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Chair : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Cipher { get; set; }

        public int? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        public Chair() : base()
        {
            Teachers = new List<Teacher>();
        }
    }
}