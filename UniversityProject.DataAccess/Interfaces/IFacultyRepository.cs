using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface IFacultyRepository : IBaseRepository<Faculty>
    {
        Task<Faculty> FindFacultyByName(string name);
        Task<Faculty> FindFacultyByCipher(string cipher);
    }
}