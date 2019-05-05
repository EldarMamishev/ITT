using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Enums;
using UniversityProject.BusinessLogic.Helpers.Interfaces;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Entities.Enums;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        private IFacultyRepository _facultyRepository;
        private IChairRepository _chairRepository;
        private IGroupRepository _groupRepository;

        private IFacultyMapper _facultyMapper;
        private IChairMapper _chairMapper;
        private IGroupMapper _groupMapper;

        private IDateParseHelper _dateParseHelper;
        #endregion

        #region Constructors
        public AdminService(
            IFacultyRepository facultyRepository,
            IChairRepository chairRepository,
            IGroupRepository groupRepository,
            IFacultyMapper facultyMapper,
            IChairMapper chairMapper,
            IGroupMapper groupMapper,
            IDateParseHelper dateParseHelper)
        {
            _facultyRepository = facultyRepository;
            _chairRepository = chairRepository;
            _groupRepository = groupRepository;

            _facultyMapper = facultyMapper;
            _chairMapper = chairMapper;
            _groupMapper = groupMapper;

            _dateParseHelper = dateParseHelper;
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

            var changeCiphers = false;

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

                changeCiphers = true;
            }

            faculty = await _facultyRepository.Get(viewModel.Id);

            if (faculty is null)
            {
                throw new AdminException("Entered faculty doesn't exist.");
            }

            _facultyMapper.MapFacultyEditViewModelToFacultyModel(faculty, viewModel);

            await _facultyRepository.Update(faculty);

            if (changeCiphers)
            {
                await UpdateFacultiesCiphers(UpdatingCipherType.Faculty, faculty.Id);
            }
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
            Chair chair = await _chairRepository.Get(viewModel.Id);

            if (chair is null)
            {
                throw new AdminException("Entered chair doesn't exist.");
            }

            var changeCiphers = false;

            if (!(chair.Name.ToUpper().Equals(viewModel.Name.ToUpper())))
            {
                chair = await _chairRepository.FindChairByName(viewModel.Name);

                if (!(chair is null))
                {
                    throw new AdminException("Entered chair already exist.");
                }
            }

            if (!(chair.Cipher.ToUpper().Equals(viewModel.Cipher.ToUpper())))
            {
                chair = await _chairRepository.FindChairByCipher(viewModel.Cipher);

                if (!(chair is null))
                {
                    throw new AdminException("Entered cipher already occupied.");
                }

                chair.Cipher = viewModel.Cipher;

                changeCiphers = true;
            }

            if (!chair.FacultyId.Equals(viewModel.FacultyId))
            {
                Faculty faculty = await _facultyRepository.Get(viewModel.FacultyId);

                if (faculty is null)
                {
                    throw new AdminException("Selected faculty doesn't exist.");
                }

                Chair checkExistedCipher = await _chairRepository.FindChairByCipherAndFaculty(chair.Cipher, viewModel.FacultyId);

                if (!(checkExistedCipher is null))
                {
                    throw new AdminException("Entered chair's cipher has already existed.");
                }

                changeCiphers = true;
            }

            _chairMapper.MapChairEditViewModelToChairModel(chair, viewModel);

            await _chairRepository.Update(chair);

            if (changeCiphers)
            {
                await UpdateFacultiesCiphers(UpdatingCipherType.Chair, chair.Id);
            }
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

        #region Groups
        public async Task<ShowGroupsAdminView> ShowGroups()
        {
            List<Group> groups = await _groupRepository.GetAllGroups();

            ShowGroupsAdminView result = _groupMapper.MapAllGroupsToViewModel(groups);

            return result;
        }
        //TODO CACHEDATA
        public async Task<CreateGroupDataAdminView> LoadDataForCreateGroupPage()
        {
            var result = new CreateGroupDataAdminView();

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;

            foreach (Faculty faculty in faculties)
            {
                var facultyViewItem = new FacultyCreateGroupDataAdminViewItem();

                facultyViewItem.Id = faculty.Id;
                facultyViewItem.FacultyName = faculty.Name;

                result.Faculties.Add(facultyViewItem);
            }

            if (!(faculties is null))
            {
                int facultyId = faculties.FirstOrDefault().Id;

                var chairs = await _chairRepository.GetAllChairsByFacultyId(facultyId) as List<Chair>;

                foreach (Chair chair in chairs)
                {
                    var chairViewItem = new ChairCreateGroupDataAdminViewItem();

                    chairViewItem.Id = chair.Id;
                    chairViewItem.ChairName = chair.Name;

                    result.Chairs.Add(chairViewItem);
                }
            }
            
            result.CourseNumberTypes = Enum.GetValues(typeof(CourseNumberType)).Cast<int>()
                .Where(item => !item.Equals(0)).ToList();

            return result;
        }
        //TODO CACHEDATA
        public async Task<JsonResult> LoadChairsByFacultyId(int facultyId)
        {
            var result = new List<ChairCreateGroupDataAdminViewItem>();
            var chairs = await _chairRepository.GetAllChairsByFacultyId(facultyId) as List<Chair>;

            foreach (Chair chair in chairs)
            {
                var chairViewItem = new ChairCreateGroupDataAdminViewItem();

                chairViewItem.Id = chair.Id;
                chairViewItem.ChairName = chair.Name;

                result.Add(chairViewItem);
            }

            return new JsonResult(result);
        }

        public async Task CreateGroup(CreateGroupAdminView viewModel)
        {
            var group = new Group();

            Chair chair = await _chairRepository.GetChairWithFacultyById(viewModel.ChairId);

            if (chair is null)
            {
                throw new AdminException("Selected chair doesn't exist.");
            }

            group.CourseNumberType = (CourseNumberType)Enum.Parse(typeof(CourseNumberType), viewModel.CourseNumberTypeId.ToString());
            group.GroupNumber = viewModel.GroupNumber;
            group.CreationYear = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.CreationYear).Value;
            group.Cipher = $"{chair.Faculty.Cipher}.{chair.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";
            group.ChairId = viewModel.ChairId;

            Group groupItem = await _groupRepository.FindGroupByCipher(group.Cipher);
            if (!(groupItem is null))
            {
                throw new AdminException("Entered group has already existed.");
            }

            await _groupRepository.Create(group);
        }

        public async Task<EditGroupDataAdminView> EditGroup(int id)
        {
            Group group = await _groupRepository.GetWithChair(id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            var chairs = await _chairRepository.GetAll() as List<Chair>;

            EditGroupDataAdminView viewModel = _groupMapper.MapToEditGroupDataModel(group, chairs);

            return viewModel;
        }

        public async Task EditGroup(EditGroupAdminView viewModel)
        {
            Group group = await _groupRepository.Get(viewModel.Id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            Chair chair = await _chairRepository.GetChairWithFacultyById(viewModel.ChairId);

            if (chair is null)
            {
                throw new AdminException("Selected chair doesn't exist.");
            }

            group.CourseNumberType = (CourseNumberType)Enum.Parse(typeof(CourseNumberType), viewModel.CourseNumberTypeId.ToString());
            group.GroupNumber = viewModel.GroupNumber;
            group.CreationYear = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.CreationYear).Value;
            group.ChairId = viewModel.ChairId;

            var newCipher = $"{chair.Faculty.Cipher}.{chair.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";

            if (!group.Cipher.Equals(newCipher))
            {
                Group checkGroup = await _groupRepository.FindGroupByCipher(newCipher);

                if (!(checkGroup is null))
                {
                    throw new AdminException("Entered group has already existed.");
                }

                group.Cipher = newCipher;

                await _groupRepository.Update(group);
            }
        }

        public async Task DeleteGroup(int id)
        {
            Group group = await _groupRepository.Get(id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            await _groupRepository.Delete(id);
        }
        #endregion

        #endregion

        #region Private Methods
        private async Task UpdateFacultiesCiphers(UpdatingCipherType updatingType, int id)
        {
            var groups = new List<Group>();

            if (updatingType.Equals(UpdatingCipherType.Faculty))
            {
                groups = await _groupRepository.FindGroupsByFacultyId(id);
            }

            if (updatingType.Equals(UpdatingCipherType.Chair))
            {
                groups = await _groupRepository.FindGroupsByChairId(id);
            }

            foreach (Group group in groups)
            {
                var newCipher = $"{group.Chair.Faculty.Cipher}.{group.Chair.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";
                group.Cipher = newCipher;
            }

            await _groupRepository.UpdateMultiple(groups);
        }
        #endregion
    }
}