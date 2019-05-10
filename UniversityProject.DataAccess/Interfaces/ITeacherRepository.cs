using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersWithSubjectAndChair();
    }
}