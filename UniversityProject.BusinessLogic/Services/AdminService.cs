using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
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
        public async Task<ShowFacultiesAdminView> ShowFaculties()
        {
            List<Faculty> faculties = await _facultyRepository.GetAll() as List<Faculty>;

            ShowFacultiesAdminView result = _facultyMapper.MapAllFacultiesToViewModel(faculties);

            return result;
        }

        public async Task CreateFaculty(CreateFacultyAdminView viewModel)
        {
            Faculty faculty = await _facultyRepository.FindFacultyByName(viewModel.Name);

            if (!(faculty is null))
            {
                throw new AdminException("Such faculty already exist.");
            }

            faculty = await _facultyRepository.FindFacultyByCipher(viewModel.Cipher);

            if (!(faculty is null))
            {
                throw new AdminException("Such cipher already occupied.");
            }

            faculty = _facultyMapper.MapToFacultyModel(viewModel);

            await _facultyRepository.Create(faculty);
        }

        public async Task<EditFacultyAdminView> EditFaculty(int id)
        {
            Faculty faculty = await _facultyRepository.Get(id);

            EditFacultyAdminView result = _facultyMapper.MapToEditFacultyViewModel(faculty);

            return result;
        }

        public async Task EditFaculty(EditFacultyAdminView viewModel)
        {
            Faculty faculty = null;

            if (!(viewModel.LastName.Equals(viewModel.Name)))
            {
                faculty = await _facultyRepository.FindFacultyByName(viewModel.Name);

                if (!(faculty is null))
                {
                    throw new AdminException("Such faculty already exist.");
                }
            }

            if (!(viewModel.LastCipher.Equals(viewModel.Cipher)))
            {
                faculty = await _facultyRepository.FindFacultyByCipher(viewModel.Cipher);

                if (!(faculty is null))
                {
                    throw new AdminException("Such cipher already occupied.");
                }
            }

            faculty = await _facultyRepository.Get(viewModel.Id);

            if (faculty is null)
            {
                throw new AdminException("Such faculty doesn't exist.");
            }

            _facultyMapper.MapFacultyEditViewModelToFacultyModel(faculty, viewModel);

            await _facultyRepository.Update(faculty);
        }

        public async Task DeleteFaculty(int id)
        {
            Faculty faculty = await _facultyRepository.Get(id);

            if (faculty is null)
            {
                throw new AdminException("Such faculty doesn't exist.");
            }

            await _facultyRepository.Delete(id);
        }
        #endregion
    }
}