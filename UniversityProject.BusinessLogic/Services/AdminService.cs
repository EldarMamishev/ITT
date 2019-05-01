using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        private IFacultyRepository _facultyRepository;

        private IFacultyMapper _facultyMapper;
        #endregion

        #region Constructors
        public AdminService(IFacultyRepository facultyRepository, IFacultyMapper facultyMapper)
        {
            _facultyRepository = facultyRepository;
            _facultyMapper = facultyMapper;
        }
        #endregion

        #region Public Methods
        public async Task CreateFaculty(CreateFacultyAdminView viewModel)
        {
            Faculty faculty = _facultyMapper.MapToFacultyModel(viewModel);
            await _facultyRepository.Create(faculty);
        }
        #endregion
    }
}