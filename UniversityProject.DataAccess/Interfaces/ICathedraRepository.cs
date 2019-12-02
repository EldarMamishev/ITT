using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface ICathedraRepository : IBaseRepository<Cathedra>
    {
        Task<Cathedra> GetCathedraWithFacultyById(int id);
        Task<Cathedra> GetCathedraByIdAndFacultyById(int facultyId, int cathedraId);
        Task<List<Cathedra>> GetAllCathedrasByFacultyId(int facultyId);
        Task<List<Cathedra>> GetAllCathedrasWithFaculty();
        Task<Cathedra> FindCathedraByName(string name);
        Task<Cathedra> FindCathedraByCipher(string cipher);
        Task<Cathedra> FindCathedraByCipherAndFaculty(string cipher, int facultyId);
    }
}