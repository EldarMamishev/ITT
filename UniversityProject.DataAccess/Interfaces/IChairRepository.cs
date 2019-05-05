using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface IChairRepository : IBaseRepository<Chair>
    {
        Task<Chair> GetChairWithFacultyById(int id);
        Task<List<Chair>> GetAllChairsByFacultyId(int facultyId);
        Task<List<Chair>> GetAllChairsWithFaculty();
        Task<Chair> FindChairByName(string name);
        Task<Chair> FindChairByCipher(string cipher);
        Task<Chair> FindChairByCipherAndFaculty(string cipher, int facultyId);
    }
}