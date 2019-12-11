using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityProject.Entities.Entities.Base;

namespace UniversityProject.Entities.Entities
{
    public class ResultNote : BaseEntity
    {
        public int? UserTestSessionId { get; set; }
        [ForeignKey(nameof(UserTestSessionId))]
        public UserTestSession UserTestSession { get; set; }

        public ResultNote()
        {

        }
    }
}
