using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<List<Student>> GetAllStudentsByCompany(int companyId);
        Task<Student> GetStudentByName(string name);
    }
}
