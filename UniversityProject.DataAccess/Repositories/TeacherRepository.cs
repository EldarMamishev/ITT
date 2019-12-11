using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class TeacherRepository : EFBaseIdentityRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Teacher>> GetAllTeachersByCompany(int companyId)
        {
            List<Teacher> teachers = await _context.Teachers
                .Where(item => item.CompanyId.Equals(companyId))
                .ToListAsync();

            return teachers;
        }

        public async Task<Teacher> GetTeacherByName(string name)
        {
            Teacher teacher = await _context.Teachers
                .FirstOrDefaultAsync(item => item.UserName.ToUpper().Equals(name.ToUpper()));

            return teacher;
        }
    }
}