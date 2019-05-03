using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        private IFacultyRepository _facultyRepository;
        private IChairRepository _chairRepository;

        private IFacultyMapper _facultyMapper;
        private IChairMapper _chairMapper;
        #endregion

        #region Constructors
        public AdminService(
            IFacultyRepository facultyRepository,
            IChairRepository chairRepository, 
            IFacultyMapper facultyMapper,
            IChairMapper chairMapper)
        {
            _facultyRepository = facultyRepository;
            _chairRepository = chairRepository;

            _facultyMapper = facultyMapper;
            _chairMapper = chairMapper;
        }
        #endregion

        #region Public Methods

        #region Faculties
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
                throw new AdminException("Entered faculty already exist.");
            }

            faculty = await _facultyRepository.FindFacultyByCipher(viewModel.Cipher);

            if (!(faculty is null))
            {
                throw new AdminException("Entered cipher already occupied.");
            }

            faculty = _facultyMapper.MapToFacultyModel(viewModel);

            await _facultyRepository.Create(faculty);
        }

        public async Task<EditFacultyAdminView> EditFaculty(int id)
        {
            Faculty faculty = await _facultyRepository.Get(id);

            if (faculty is null)
            {
                throw new AdminException("Selected faculty doesn't exist.");
            }

            EditFacultyAdminView result = _facultyMapper.MapToEditFacultyViewModel(faculty);

            return result;
        }

        public async Task EditFaculty(EditFacultyAdminView viewModel)
        {
            Faculty faculty = null;

            if (!(viewModel.LastName.ToUpper().Equals(viewModel.Name.ToUpper())))
            {
                faculty = await _facultyRepository.FindFacultyByName(viewModel.Name);

                if (!(faculty is null))
                {
                    throw new AdminException("Entered faculty already exist.");
                }
            }

            if (!(viewModel.LastCipher.ToUpper().Equals(viewModel.Cipher.ToUpper())))
            {
                faculty = await _facultyRepository.FindFacultyByCipher(viewModel.Cipher);

                if (!(faculty is null))
                {
                    throw new AdminException("Entered cipher already occupied.");
                }
            }

            faculty = await _facultyRepository.Get(viewModel.Id);

            if (faculty is null)
            {
                throw new AdminException("Entered faculty doesn't exist.");
            }

            _facultyMapper.MapFacultyEditViewModelToFacultyModel(faculty, viewModel);

            await _facultyRepository.Update(faculty);
        }

        public async Task DeleteFaculty(int id)
        {
            Faculty faculty = await _facultyRepository.Get(id);

            if (faculty is null)
            {
                throw new AdminException("Selected faculty doesn't exist.");
            }

            await _facultyRepository.Delete(id);
        }
        #endregion

        #region Chairs
        public async Task<ShowChairsAdminView> ShowChairs()
        {
            List<Chair> chairs = await _chairRepository.GetAllChairsWithFaculty();

            ShowChairsAdminView result = _chairMapper.MapAllChairsToViewModel(chairs);

            return result;
        }

        public async Task<CreateChairDataAdminView> LoadDataForCreateChairPage()
        {
            var faculties = await _facultyRepository.GetAll() as List<Faculty>;

            var viewModel = new CreateChairDataAdminView();

            foreach (Faculty faculty in faculties)
            {
                var item = new CreateChairDataAdminViewItem();

                item.Id = faculty.Id;
                item.FacultyName = faculty.Name;

                viewModel.Faculties.Add(item);
            }

            return viewModel;
        }

        public async Task CreateChair(CreateChairAdminView viewModel)
        {
            Chair chair = await _chairRepository.FindChairByName(viewModel.Name);

            if (!(chair is null))
            {
                throw new AdminException("Entered chair already exist.");
            }

            chair = await _chairRepository.FindChairByCipher(viewModel.Cipher); 

            if (!(chair is null))
            {
                throw new AdminException("Entered cipher already occupied.");
            }

            Faculty faculty = await _facultyRepository.Get(viewModel.FacultyId);

            if (faculty is null)
            {
                throw new AdminException("Selected faculty doesn't exist.");
            }

            chair = _chairMapper.MapToChairModel(viewModel);

            await _chairRepository.Create(chair);
        }

        public async Task<EditChairDataAdminView> EditChair(int id)
        {
            Chair chair = await _chairRepository.Get(id);

            if (chair is null)
            {
                throw new AdminException("Selected chair doesn't exist.");
            }

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;

            EditChairDataAdminView viewModel = _chairMapper.MapToEditChairDataModel(chair, faculties);
            
            return viewModel;
        }

        public async Task EditChair(EditChairAdminView viewModel)
        {
            Chair chair = null;
            
            if (!(viewModel.PreviousName.ToUpper().Equals(viewModel.Name.ToUpper())))
            {
                chair = await _chairRepository.FindChairByName(viewModel.Name);

                if (!(chair is null))
                {
                    throw new AdminException("Entered chair already exist.");
                }
            }

            if (!(viewModel.PreviousCipher.ToUpper().Equals(viewModel.Cipher.ToUpper())))
            {
                chair = await _chairRepository.FindChairByCipher(viewModel.Cipher);

                if (!(chair is null))
                {
                    throw new AdminException("Entered cipher already occupied.");
                }
            }

            Faculty faculty = await _facultyRepository.Get(viewModel.FacultyId);

            if (faculty is null)
            {
                throw new AdminException("Selected faculty doesn't exist.");
            }

            chair = await _chairRepository.Get(viewModel.Id);

            if (chair is null)
            {
                throw new AdminException("Entered chair doesn't exist.");
            }

            _chairMapper.MapChairEditViewModelToChairModel(chair, viewModel);

            await _chairRepository.Update(chair);
        }

        public async Task DeleteChair(int id)
        {
            Chair chair = await _chairRepository.Get(id);

            if (chair is null)
            {
                throw new AdminException("Selected chair doesn't exist.");
            }

            await _chairRepository.Delete(id);
        }
        #endregion

        #endregion
    }
}