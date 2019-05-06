﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<Group> GetWithChair(int id);
        Task<Group> GetWithChairAndFaculty(int id);
        Task<Group> FindGroupByCipher(string cipher);
        Task<List<Group>> GetAllGroups();
        Task<List<Group>> FindGroupsByFacultyId(int id);
        Task<List<Group>> FindGroupsByChairId(int id);
    }
}