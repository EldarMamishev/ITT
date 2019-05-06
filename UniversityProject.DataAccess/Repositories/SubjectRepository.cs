using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class SubjectRepository : EFBaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Subject> FindByName(string subjectName)
        {
            Subject subject = await _context.Subjects
                .FirstOrDefaultAsync(item => item.Name.ToUpper().Equals(subjectName.ToUpper()));

            return subject;
        }
    }
}