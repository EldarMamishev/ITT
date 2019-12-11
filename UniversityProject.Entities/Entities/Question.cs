using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public int? TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        public Test Test { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
