﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Enums;
using UniversityProject.BusinessLogic.Extentions;
using UniversityProject.BusinessLogic.Helpers.Interfaces;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.BusinessLogic.Providers.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.DataAccess.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Entities.Enums;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        private IFacultyRepository _facultyRepository;
        private IChairRepository _chairRepository;
        private IGroupRepository _groupRepository;
        private ISubjectRepository _subjectRepository;
        private ITeacherSubjectRepository _teacherSubjectRepository;
        private ITeacherRepository _teacherRepository;

        private IFacultyMapper _facultyMapper;
        private IChairMapper _chairMapper;
        private IGroupMapper _groupMapper;
        private ISubjectMapper _subjectMapper;
        private ITeacherMapper _teacherMapper;
        private IAccountMapper _accountMapper;

        private IDateParseHelper _dateParseHelper;

        private IEmailProvider _emailProvider;

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        #endregion

        #region Constructors
        public AdminService(
            IFacultyRepository facultyRepository,
            IChairRepository chairRepository,
            IGroupRepository groupRepository,
            ISubjectRepository subjectRepository,
            ITeacherSubjectRepository teacherSubjectRepository,
            ITeacherRepository teacherRepository,
            IFacultyMapper facultyMapper,
            IChairMapper chairMapper,
            IGroupMapper groupMapper,
            ISubjectMapper subjectMapper,
            ITeacherMapper teacherMapper,
            IAccountMapper accountMapper,
            IDateParseHelper dateParseHelper,
            IEmailProvider emailProvider,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _facultyRepository = facultyRepository;
            _chairRepository = chairRepository;
            _groupRepository = groupRepository;
            _subjectRepository = subjectRepository;
            _teacherSubjectRepository = teacherSubjectRepository;
            _teacherRepository = teacherRepository;

            _facultyMapper = facultyMapper;
            _chairMapper = chairMapper;
            _groupMapper = groupMapper;
            _subjectMapper = subjectMapper;
            _teacherMapper = teacherMapper;
            _accountMapper = accountMapper;

            _dateParseHelper = dateParseHelper;

            _emailProvider = emailProvider;

            _userManager = userManager;
            _signInManager = signInManager;
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
            Faculty faculty = await _facultyRepository.Get(viewModel.Id);

            if (faculty is null)
            {
                throw new AdminException("Entered faculty doesn't exist.");
            }

            var changeCiphers = false;

            if (!(faculty.Name.ToUpper().Equals(viewModel.Name.ToUpper())))
            {
                faculty = await _facultyRepository.FindFacultyByName(viewModel.Name);

                if (!(faculty is null))
                {
                    throw new AdminException("Entered faculty already exist.");
                }
            }

            if (!(faculty.Cipher.ToUpper().Equals(viewModel.Cipher.ToUpper())))
            {
                faculty = await _facultyRepository.FindFacultyByCipher(viewModel.Cipher);

                if (!(faculty is null))
                {
                    throw new AdminException("Entered cipher already occupied.");
                }

                changeCiphers = true;
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
            var viewModel = new EditGroupDataAdminView();

            Group group = await _groupRepository.GetWithChairAndFaculty(id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;
            var chairs = await _chairRepository.GetAllChairsByFacultyId(group.Chair.FacultyId.Value) as List<Chair>;

            viewModel = _groupMapper.MapToEditGroupDataModel(group, faculties, chairs);

            return viewModel;
        }

        public async Task EditGroup(EditGroupAdminView viewModel)
        {
            Group group = await _groupRepository.GetWithChair(viewModel.Id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            group.CourseNumberType = (CourseNumberType)Enum.Parse(typeof(CourseNumberType), viewModel.CourseNumberTypeId.ToString());
            group.GroupNumber = viewModel.GroupNumber;
            group.CreationYear = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.CreationYear).Value;

            Chair chair = group.Chair;

            if (!group.ChairId.Equals(viewModel.ChairId))
            {
                chair = await _chairRepository.GetChairWithFacultyById(viewModel.ChairId);

                if (chair is null)
                {
                    throw new AdminException("Selected chair doesn't exist.");
                }

                group.ChairId = viewModel.ChairId;
            }

            var newCipher = $"{chair.Faculty.Cipher}.{chair.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";

            if (group.Cipher.Equals(newCipher))
            {
                return;
            }

            Group checkGroup = await _groupRepository.FindGroupByCipher(newCipher);

            if (!(checkGroup is null))
            {
                throw new AdminException("Entered group has already existed.");
            }

            group.Cipher = newCipher;

            await _groupRepository.Update(group);
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

        #region Subjects
        public async Task<ShowSubjectsAdminView> ShowSubjects()
        {
            var subjects = await _subjectRepository.GetAll() as List<Subject>;

            ShowSubjectsAdminView result = _subjectMapper.MapAllSubjectsToViewModel(subjects);

            return result;
        }

        public async Task<ResponseSubjectView> CreateSubject(string subjectName)
        {
            Subject subject = await _subjectRepository.FindByName(subjectName);

            if (!(subject is null))
            {
                throw new AdminException("Such subject has already existed.");
            }

            subject = new Subject();
            subject.Name = subjectName;

            await _subjectRepository.Create(subject);

            var viewModel = new ResponseSubjectView();

            viewModel.Id = subject.Id;
            viewModel.Name = subject.Name;

            return viewModel;
        }

        public async Task<ResponseSubjectView> EditSubject(RequestSubjectView requestViewModel)
        {
            Subject subject = await _subjectRepository.Get(requestViewModel.Id);

            if (subject is null)
            {
                throw new AdminException("Selected subject doesn't exist.");
            }

            if (!subject.Name.ToUpper().Equals(requestViewModel.SubjectName.ToUpper()))
            {
                Subject checkExistingsubject = await _subjectRepository.FindByName(requestViewModel.SubjectName);

                if (!(checkExistingsubject is null))
                {
                    throw new AdminException("Such subject has already existed.");
                }

                subject.Name = requestViewModel.SubjectName;

                await _subjectRepository.Update(subject);
            }

            var viewModel = new ResponseSubjectView();

            viewModel.Id = subject.Id;
            viewModel.Name = subject.Name;

            return viewModel;
        }

        public async Task DeleteSubject(int id)
        {
            Subject subject = await _subjectRepository.Get(id);

            if (subject is null)
            {
                throw new AdminException("Selected subject doesn't exist.");
            }

            await _subjectRepository.Delete(id);
        }
        #endregion

        #region Teachers
        public async Task<ShowTeachersAdminView> ShowTeachers()
        {
            List<Teacher> teachers = await _teacherRepository.GetAllTeachersWithSubjectAndChair();

            ShowTeachersAdminView result = _teacherMapper.MapTeacherModelsToViewModels(teachers);

            return result;
        }

        public async Task<RegisterNewTeacherUserDataAccountView> LoadDataForRegisterTeacherPage()
        {
            var result = new RegisterNewTeacherUserDataAccountView();

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;

            if (!(faculties is null))
            {
                _teacherMapper.MapAllFacultiesToViewModel(faculties, result);

                int facultyId = faculties.FirstOrDefault().Id;

                var chairs = await _chairRepository.GetAllChairsByFacultyId(facultyId) as List<Chair>;

                if (!(chairs is null))
                {
                    _teacherMapper.MapAllChairsToViewModel(chairs, result);
                }
            }

            var subjects = await _subjectRepository.GetAll() as List<Subject>;

            if (!(faculties is null))
            {
                _teacherMapper.MapAllSubjectsToViewModel(subjects, result);
            }

            return result;
        }

        public async Task RegisterTeacher(RegisterNewTeacherUserAccountView viewModel)
        {
            var teacher = new Teacher();

            teacher.Email = viewModel.Email;
            teacher.UserName = viewModel.Username;

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AdminException("Passwords are different");
            }

            if (!(await _userManager.FindByEmailAsync(viewModel.Email) is null) || !(await _userManager.FindByNameAsync(viewModel.Username) is null))
            {
                throw new AdminException("Account with such Email or UserID already exists");
            }

            Chair chair = await _chairRepository.GetChairByIdAndFacultyById(viewModel.FacultyId, viewModel.ChairId);

            if (chair is null)
            {
                throw new AdminException("Selected chair doesn't exist.");
            }

            Subject subject = await _subjectRepository.Get(viewModel.SubjectId);

            if (subject is null)
            {
                throw new AdminException("Selected subject doesn't exist.");
            }

            teacher.BirthDate = _dateParseHelper.ParseStringToDatetime(viewModel.BirthDate);

            _accountMapper.MapTeacherViewModelToModel(viewModel, teacher);
            /// TODOOOOOOOOOOO
            teacher.EmailConfirmed = true;
            ///
            IdentityResult result = await _userManager.CreateAsync(teacher, viewModel.Password);

            if (!result.Succeeded)
            {
                string responseError = result.GetFirstError();

                throw new AdminException(responseError);
            }

            ApplicationUser registeredTeacher = await _userManager.FindByNameAsync(viewModel.Username);

            await _userManager.AddToRoleAsync(registeredTeacher, ApplicationConstants.TEACHER_ROLE);

            var teacherSubject = new TeacherSubject();

            teacherSubject.SubjectId = subject.Id;
            teacherSubject.TeacherId = teacher.Id;

            await _teacherSubjectRepository.Create(teacherSubject);
        }

        public async Task<EditTeacherDataAccountView> LoadDataForEditTeacherAccount(string userName)
        {
            Teacher teacher = await _teacherRepository.GetTeacherWithSubjectAndChair(userName);

            if (teacher is null)
            {
                throw new AdminException("User not found");
            }

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;
            var chairs = await _chairRepository.GetAllChairsByFacultyId(teacher.Chair.FacultyId.Value) as List<Chair>;
            var subjects = await _subjectRepository.GetAll() as List<Subject>;

            EditTeacherDataAccountView viewModel = _teacherMapper.MapEditTeacherModelsToEditViewModels(teacher, faculties, chairs, subjects);

            return viewModel;
        }

        public async Task<ResponseAddSubjectToTeacherView> AddSubjectToTeacher(RequestAddSubjectToTeacherView viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user is null)
            {
                throw new AdminException("User not found.");
            }

            Teacher teacher = await _teacherRepository.GetTeacherWithSubjectAndChair(viewModel.Username);
            TeacherSubject checkExistingItem = teacher.TeacherSubjects.FirstOrDefault(item => item.Subject.Id.Equals(viewModel.SubjectId));

            if (!(checkExistingItem is null))
            {
                throw new AdminException("Teacher has already had this subject.");
            }

            Subject subject = await _subjectRepository.Get(viewModel.SubjectId);

            if (subject is null)
            {
                throw new AdminException("Subject is not found");
            }

            var teacherSubject = new TeacherSubject();

            teacherSubject.Subject = subject;
            teacherSubject.Teacher = teacher;

            await _teacherSubjectRepository.Create(teacherSubject);

            var responseViewModel = new ResponseAddSubjectToTeacherView();

            responseViewModel.Id = subject.Id;
            responseViewModel.Name = subject.Name;

            return responseViewModel;
        }

        public async Task DeleteSubjectFromTeacher(RequestDeleteSubjectFromTeacherView requestViewModel)
        {
            Teacher teacher = await _teacherRepository.GetTeacherWithSubjectAndChair(requestViewModel.Username);
            TeacherSubject deleteSubjectItem = teacher.TeacherSubjects.FirstOrDefault(item => item.Subject.Id.Equals(requestViewModel.SubjectId));

            if (deleteSubjectItem is null)
            {
                throw new AdminException("Subject is not found");
            }

            await _teacherSubjectRepository.Delete(deleteSubjectItem.Id);
        }

        public async Task EditTeacherInformation(EditTeacherInformationView viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username) as Teacher;

            if (user is null)
            {
                throw new AdminException("User not found.");
            }

            Chair chair = await _chairRepository.GetChairByIdAndFacultyById(viewModel.FacultyId , viewModel.ChairId);

            if (chair is null)
            {
                throw new AdminException("Selected chair doesn't exist.");
            }

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MiddleName = viewModel.MiddleName;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.BirthDate = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.BirthDate).Value;

            user.Country = viewModel.Country;
            user.City = viewModel.City;
            user.AddressLine = viewModel.AddressLine;

            user.Chair = chair;

            await _userManager.UpdateAsync(user);
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