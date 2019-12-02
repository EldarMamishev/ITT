using Microsoft.AspNetCore.Identity;
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
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;
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
        private ICathedraRepository _cathedraRepository;
        private IGroupRepository _groupRepository;
        private ISubjectRepository _subjectRepository;
        private ITeacherSubjectRepository _teacherSubjectRepository;
        private ITeacherRepository _teacherRepository;

        private IFacultyMapper _facultyMapper;
        private ICathedraMapper _cathedraMapper;
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
            ICathedraRepository cathedraRepository,
            IGroupRepository groupRepository,
            ISubjectRepository subjectRepository,
            ITeacherSubjectRepository teacherSubjectRepository,
            ITeacherRepository teacherRepository,
            IFacultyMapper facultyMapper,
            ICathedraMapper cathedraMapper,
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
            _cathedraRepository = cathedraRepository;
            _groupRepository = groupRepository;
            _subjectRepository = subjectRepository;
            _teacherSubjectRepository = teacherSubjectRepository;
            _teacherRepository = teacherRepository;

            _facultyMapper = facultyMapper;
            _cathedraMapper = cathedraMapper;
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

        #region Cathedras
        public async Task<ShowCathedrasAdminView> ShowCathedras()
        {
            List<Cathedra> cathedras = await _cathedraRepository.GetAllCathedrasWithFaculty();

            ShowCathedrasAdminView result = _cathedraMapper.MapAllCathedrasToViewModel(cathedras);

            return result;
        }

        public async Task<CreateCathedraDataAdminView> LoadDataForCreateCathedraPage()
        {
            var faculties = await _facultyRepository.GetAll() as List<Faculty>;

            var viewModel = new CreateCathedraDataAdminView();

            foreach (Faculty faculty in faculties)
            {
                var item = new CreateCathedraDataAdminViewItem();

                item.Id = faculty.Id;
                item.FacultyName = faculty.Name;

                viewModel.Faculties.Add(item);
            }

            return viewModel;
        }

        public async Task CreateCathedra(CreateCathedraAdminView viewModel)
        {
            Cathedra cathedra = await _cathedraRepository.FindCathedraByName(viewModel.Name);

            if (!(cathedra is null))
            {
                throw new AdminException("Entered cathedra already exist.");
            }

            cathedra = await _cathedraRepository.FindCathedraByCipher(viewModel.Cipher);

            if (!(cathedra is null))
            {
                throw new AdminException("Entered cipher already occupied.");
            }

            Faculty faculty = await _facultyRepository.Get(viewModel.FacultyId);

            if (faculty is null)
            {
                throw new AdminException("Selected faculty doesn't exist.");
            }

            cathedra = _cathedraMapper.MapToCathedraModel(viewModel);

            await _cathedraRepository.Create(cathedra);
        }

        public async Task<EditCathedraDataAdminView> EditCathedra(int id)
        {
            Cathedra cathedra = await _cathedraRepository.Get(id);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
            }

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;

            EditCathedraDataAdminView viewModel = _cathedraMapper.MapToEditCathedraDataModel(cathedra, faculties);

            return viewModel;
        }

        public async Task EditCathedra(EditCathedraAdminView viewModel)
        {
            Cathedra cathedra = await _cathedraRepository.Get(viewModel.Id);

            if (cathedra is null)
            {
                throw new AdminException("Entered cathedra doesn't exist.");
            }

            var changeCiphers = false;

            if (!(cathedra.Name.ToUpper().Equals(viewModel.Name.ToUpper())))
            {
                cathedra = await _cathedraRepository.FindCathedraByName(viewModel.Name);

                if (!(cathedra is null))
                {
                    throw new AdminException("Entered cathedra already exist.");
                }
            }

            if (!(cathedra.Cipher.ToUpper().Equals(viewModel.Cipher.ToUpper())))
            {
                cathedra = await _cathedraRepository.FindCathedraByCipher(viewModel.Cipher);

                if (!(cathedra is null))
                {
                    throw new AdminException("Entered cipher already occupied.");
                }

                cathedra.Cipher = viewModel.Cipher;

                changeCiphers = true;
            }

            if (!cathedra.FacultyId.Equals(viewModel.FacultyId))
            {
                Faculty faculty = await _facultyRepository.Get(viewModel.FacultyId);

                if (faculty is null)
                {
                    throw new AdminException("Selected faculty doesn't exist.");
                }

                Cathedra checkExistedCipher = await _cathedraRepository.FindCathedraByCipherAndFaculty(cathedra.Cipher, viewModel.FacultyId);

                if (!(checkExistedCipher is null))
                {
                    throw new AdminException("Entered cathedra's cipher has already existed.");
                }

                changeCiphers = true;
            }

            _cathedraMapper.MapCathedraEditViewModelToCathedraModel(cathedra, viewModel);

            await _cathedraRepository.Update(cathedra);

            if (changeCiphers)
            {
                await UpdateFacultiesCiphers(UpdatingCipherType.Cathedra, cathedra.Id);
            }
        }

        public async Task DeleteCathedra(int id)
        {
            Cathedra cathedra = await _cathedraRepository.Get(id);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
            }

            await _cathedraRepository.Delete(id);
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

                var cathedras = await _cathedraRepository.GetAllCathedrasByFacultyId(facultyId) as List<Cathedra>;

                foreach (Cathedra cathedra in cathedras)
                {
                    var cathedraViewItem = new CathedraCreateGroupDataAdminViewItem();

                    cathedraViewItem.Id = cathedra.Id;
                    cathedraViewItem.CathedraName = cathedra.Name;

                    result.Cathedras.Add(cathedraViewItem);
                }
            }

            result.CourseNumberTypes = Enum.GetValues(typeof(CourseNumberType)).Cast<int>()
                .Where(item => !item.Equals(0)).ToList();

            return result;
        }
        //TODO CACHEDATA
        public async Task<JsonResult> LoadCathedrasByFacultyId(int facultyId)
        {
            var result = new List<CathedraCreateGroupDataAdminViewItem>();
            var cathedras = await _cathedraRepository.GetAllCathedrasByFacultyId(facultyId) as List<Cathedra>;

            foreach (Cathedra cathedra in cathedras)
            {
                var cathedraViewItem = new CathedraCreateGroupDataAdminViewItem();

                cathedraViewItem.Id = cathedra.Id;
                cathedraViewItem.CathedraName = cathedra.Name;

                result.Add(cathedraViewItem);
            }

            return new JsonResult(result);
        }

        public async Task CreateGroup(CreateGroupAdminView viewModel)
        {
            var group = new Group();

            Cathedra cathedra = await _cathedraRepository.GetCathedraWithFacultyById(viewModel.CathedraId);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
            }

            group.CourseNumberType = (CourseNumberType)Enum.Parse(typeof(CourseNumberType), viewModel.CourseNumberTypeId.ToString());
            group.GroupNumber = viewModel.GroupNumber;
            group.CreationYear = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.CreationYear).Value;
            group.Cipher = $"{cathedra.Faculty.Cipher}.{cathedra.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";
            group.CathedraId = viewModel.CathedraId;

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

            Group group = await _groupRepository.GetWithCathedraAndFaculty(id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;
            var cathedras = await _cathedraRepository.GetAllCathedrasByFacultyId(group.Cathedra.FacultyId.Value) as List<Cathedra>;

            viewModel = _groupMapper.MapToEditGroupDataModel(group, faculties, cathedras);

            return viewModel;
        }

        public async Task EditGroup(EditGroupAdminView viewModel)
        {
            Group group = await _groupRepository.GetWithCathedra(viewModel.Id);

            if (group is null)
            {
                throw new AdminException("Selected group doesn't exist.");
            }

            group.CourseNumberType = (CourseNumberType)Enum.Parse(typeof(CourseNumberType), viewModel.CourseNumberTypeId.ToString());
            group.GroupNumber = viewModel.GroupNumber;
            group.CreationYear = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.CreationYear).Value;

            Cathedra cathedra = group.Cathedra;

            if (!group.CathedraId.Equals(viewModel.CathedraId))
            {
                cathedra = await _cathedraRepository.GetCathedraWithFacultyById(viewModel.CathedraId);

                if (cathedra is null)
                {
                    throw new AdminException("Selected cathedra doesn't exist.");
                }

                group.CathedraId = viewModel.CathedraId;
            }

            var newCipher = $"{cathedra.Faculty.Cipher}.{cathedra.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";

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
            List<Teacher> teachers = await _teacherRepository.GetAllTeachersWithSubjectAndCathedra();

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

                var cathedras = await _cathedraRepository.GetAllCathedrasByFacultyId(facultyId) as List<Cathedra>;

                if (!(cathedras is null))
                {
                    _teacherMapper.MapAllCathedrasToViewModel(cathedras, result);
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

            Cathedra cathedra = await _cathedraRepository.GetCathedraByIdAndFacultyById(viewModel.FacultyId, viewModel.CathedraId);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
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
            Teacher teacher = await _teacherRepository.GetTeacherWithSubjectAndCathedra(userName);

            if (teacher is null)
            {
                throw new AdminException("User not found");
            }

            var faculties = await _facultyRepository.GetAll() as List<Faculty>;
            var cathedras = await _cathedraRepository.GetAllCathedrasByFacultyId(teacher.Cathedra.FacultyId.Value) as List<Cathedra>;
            var subjects = await _subjectRepository.GetAll() as List<Subject>;

            EditTeacherDataAccountView viewModel = _teacherMapper.MapEditTeacherModelsToEditViewModels(teacher, faculties, cathedras, subjects);

            return viewModel;
        }

        public async Task<ResponseAddSubjectToTeacherView> AddSubjectToTeacher(RequestAddSubjectToTeacherView viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user is null)
            {
                throw new AdminException("User not found.");
            }

            Teacher teacher = await _teacherRepository.GetTeacherWithSubjectAndCathedra(viewModel.Username);
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
            Teacher teacher = await _teacherRepository.GetTeacherWithSubjectAndCathedra(requestViewModel.Username);
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

            Cathedra cathedra = await _cathedraRepository.GetCathedraByIdAndFacultyById(viewModel.FacultyId , viewModel.CathedraId);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
            }

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MiddleName = viewModel.MiddleName;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.BirthDate = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.BirthDate).Value;

            user.Country = viewModel.Country;
            user.City = viewModel.City;
            user.AddressLine = viewModel.AddressLine;

            user.Cathedra = cathedra;

            await _userManager.UpdateAsync(user);
        }
        #endregion

        #region Students

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

            if (updatingType.Equals(UpdatingCipherType.Cathedra))
            {
                groups = await _groupRepository.FindGroupsByCathedraId(id);
            }

            foreach (Group group in groups)
            {
                var newCipher = $"{group.Cathedra.Faculty.Cipher}.{group.Cathedra.Cipher}.{group.CreationYear.ToString("yy")}.{group.GroupNumber}";
                group.Cipher = newCipher;
            }

            await _groupRepository.UpdateMultiple(groups);
        }
        #endregion
    }
}