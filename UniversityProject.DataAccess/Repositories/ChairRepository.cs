using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class ChairRepository : EFBaseRepository<Chair>, IChairRepository
    {
        public ChairRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Chair> GetChairWithFacultyById(int id)
        {
            Chair chair = await _context.Chairs
                .Include(item => item.Faculty)
                .FirstOrDefaultAsync(item => item.Id.Equals(id));

            return chair;
        }

        public async Task<List<Chair>> GetAllChairsWithFaculty()
        {
            List<Chair> chairs = await _context.Chairs
                .Include(item => item.Faculty)
                .ToListAsync();

            return chairs;
        }

        public async Task<Chair> FindChairByName(string name)
        {
            Chair chair = await _context.Chairs.FirstOrDefaultAsync(f => f.Name.Equals(name));

            return chair;
        }

        public async Task<Chair> FindChairByCipher(string cipher)
        {
            Chair chair = await _context.Chairs
                .FirstOrDefaultAsync(f => f.Cipher.Equals(cipher));

            return chair;
        }

        public async Task<Chair> FindChairByCipherAndFaculty(string cipher, int facultyId)
        {
            Chair chair = await _context.Chairs
                .FirstOrDefaultAsync(f => f.Cipher.Equals(cipher) && f.FacultyId.Equals(facultyId));

            return chair;
        }
    }
}