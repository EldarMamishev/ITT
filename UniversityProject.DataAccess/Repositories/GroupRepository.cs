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
    public class GroupRepository : EFBaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Group> GetWithChair(int id)
        {
            Group group = await _context.Groups
                .FirstOrDefaultAsync(item => item.Id.Equals(id));

            return group;
        }

        public async Task<List<Group>> GetAllGroups()
        {
            List<Group> groups = await _context.Groups
                .Include(item => item.Chair)
                .ThenInclude(chair => chair.Faculty)
                .ToListAsync();

            return groups;
        }

        public async Task<Group> FindGroupByCipher(string cipher)
        {
            Group group = await _context.Groups
                .FirstOrDefaultAsync(item => (item.Cipher.Equals(cipher)));

            return group;
        }

        public async Task<List<Group>> FindGroupsByFacultyId(int id)
        {
            List<Group> groups = await _context.Groups
                .Include(item => item.Chair)
                .ThenInclude(chair => chair.Faculty)
                .Where(item => item.Chair.FacultyId.Equals(id))
               . ToListAsync();

            return groups;
        }

        public async Task<List<Group>> FindGroupsByChairId(int id)
        {
            List<Group> groups = await _context.Groups
                .Include(item => item.Chair)
                .ThenInclude(chair => chair.Faculty)
                .Where(item => item.ChairId.Equals(id))
               .ToListAsync();

            return groups;
        }
    }
}