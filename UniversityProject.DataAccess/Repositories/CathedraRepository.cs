using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class CathedraRepository : EFBaseRepository<Cathedra>, ICathedraRepository
    {
        public CathedraRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Cathedra> GetCathedraWithFacultyById(int id)
        {
            Cathedra cathedra = await _context.Cathedras
                .Include(item => item.Faculty)
                .FirstOrDefaultAsync(item => item.Id.Equals(id));

            return cathedra;
        }
        public async Task<Cathedra> GetCathedraByIdAndFacultyById(int facultyId, int cathedraId)
        {
            Cathedra cathedra = await _context.Cathedras
                   .FirstOrDefaultAsync(item => item.Id.Equals(cathedraId) 
                   && item.FacultyId.Equals(facultyId));

            return cathedra;
        }

        public async Task<List<Cathedra>> GetAllCathedrasByFacultyId(int facultyId)
        {
            List<Cathedra> cathedras = await _context.Cathedras
                .Include(item => item.Faculty)
                .Where(item => item.FacultyId.Equals(facultyId))
                .ToListAsync();

            return cathedras;
        }
        
        public async Task<List<Cathedra>> GetAllCathedrasWithFaculty()
        {
            List<Cathedra> cathedras = await _context.Cathedras
                .Include(item => item.Faculty)
                .ToListAsync();

            return cathedras;
        }

        public async Task<Cathedra> FindCathedraByName(string name)
        {
            Cathedra cathedra = await _context.Cathedras.FirstOrDefaultAsync(f => f.Name.Equals(name));

            return cathedra;
        }

        public async Task<Cathedra> FindCathedraByCipher(string cipher)
        {
            Cathedra cathedra = await _context.Cathedras
                .FirstOrDefaultAsync(f => f.Cipher.Equals(cipher));

            return cathedra;
        }

        public async Task<Cathedra> FindCathedraByCipherAndFaculty(string cipher, int facultyId)
        {
            Cathedra cathedra = await _context.Cathedras
                .FirstOrDefaultAsync(f => f.Cipher.Equals(cipher) && f.FacultyId.Equals(facultyId));

            return cathedra;
        }
    }
}