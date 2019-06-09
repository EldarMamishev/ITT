using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.DataAccess.Repositories.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Repositories
{
    public class TeacherSubjectRepository : EFBaseRepository<TeacherSubject>, ITeacherSubjectRepository
    {
        public TeacherSubjectRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}