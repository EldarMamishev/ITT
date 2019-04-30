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
    }
}