using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Teacher>> GetAllTeachersWithSubjectAndChair()
        {
            List<Teacher> teachers = await _context.Teachers
                .Include(user => user.Chair)
                .Include(user => user.TeacherSubjects)
                .ThenInclude(teacher => teacher.Subject)
                .ToListAsync();

            return teachers;
        }
    }
}