using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class FacultyRepository : EFBaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Faculty> FindFacultyByName(string name)
        {
            Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.Name.Equals(name));

            return faculty;
        }

        public async Task<Faculty> FindFacultyByCipher(string cipher)
        {
            Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.Cipher.Equals(cipher));

            return faculty;
        }
    }
}