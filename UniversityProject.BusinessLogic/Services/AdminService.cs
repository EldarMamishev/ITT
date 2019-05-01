using System;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        
        #endregion

        #region Constructors
        public AdminService()
        {
        }
        #endregion

        #region Public Methods
        public Task CreateFaculty(CreateFacultyAdminView viewModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
