using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<Group> FindGroupByName(string name);
        Task<Group> FindGroupByCipher(string cipher);

        Task<List<Group>> GetAllGroups();
    }
}