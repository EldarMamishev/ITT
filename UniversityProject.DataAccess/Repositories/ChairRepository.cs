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
    }
}