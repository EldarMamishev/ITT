﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityProject.Entities.Entities.Base;
using UniversityProject.Entities.Enums;

namespace UniversityProject.Entities.Entities
{
    public class Group : BaseEntity
    {
        [MaxLength(30)]
        public string Cipher { get; set; }
        public DateTime CreationYear { get; set; }
        public CourseNumberType CourseNumberType { get; set; }
        public int GroupNumber { get; set; }

        public int? ChairId { get; set; }
        [ForeignKey("ChairId")]
        public Chair Chair { get; set; }

        public Journal Journal { get; set; }

        public ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}