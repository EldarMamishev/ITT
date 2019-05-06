using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<Subject> FindByName(string subjectName);
    }
}