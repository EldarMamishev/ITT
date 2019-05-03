using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface IChairRepository : IBaseRepository<Chair>
    {
        Task<List<Chair>> GetAllChairsWithFaculty();
        Task<Chair> FindChairByName(string name);
        Task<Chair> FindChairByCipher(string cipher);
    }
}