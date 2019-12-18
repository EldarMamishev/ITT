using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class StudentRepository : EFBaseIdentityRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetAllStudentsByCompany(int companyId)
        {
            List<Student> teachers = await _context.Students
                .Where(item => item.CompanyId.Equals(companyId))
                .ToListAsync();

            return teachers;
        }

        public async Task<Student> GetStudentByName(string name)
        {
            Student teacher = await _context.Students
                .FirstOrDefaultAsync(item => item.UserName.ToUpper().Equals(name.ToUpper()));

            return teacher;
        }
    }
}
