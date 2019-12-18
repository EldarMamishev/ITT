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
using UniversityProject.ViewModels.AdminViewModels.StudentViewModels;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        #region Properties
        private ICompanyRepository _companyRepository;
        private ISubjectRepository _subjectRepository;
        private ITeacherRepository _teacherRepository;
        private IStudentRepository _studentRepository;

        private ICompanyMapper _cathedraMapper;
        private ISubjectMapper _subjectMapper;
        private ITeacherMapper _teacherMapper;
        private IStudentMapper _studentMapper;
        private IAccountMapper _accountMapper;

        private IDateParseHelper _dateParseHelper;

        private IEmailProvider _emailProvider;

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        #endregion

        #region Constructors
        public AdminService(
            ICompanyRepository cathedraRepository,
            ISubjectRepository subjectRepository,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            ICompanyMapper cathedraMapper,
            ISubjectMapper subjectMapper,
            ITeacherMapper teacherMapper,
            IStudentMapper studentMapper,
            IAccountMapper accountMapper,
            IDateParseHelper dateParseHelper,
            IEmailProvider emailProvider,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _companyRepository = cathedraRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;

            _cathedraMapper = cathedraMapper;
            _subjectMapper = subjectMapper;
            _teacherMapper = teacherMapper;
            _studentMapper = studentMapper;
            _accountMapper = accountMapper;

            _dateParseHelper = dateParseHelper;

            _emailProvider = emailProvider;

            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion
        
        #region Cathedras
        public async Task<ShowCathedrasAdminView> ShowCathedras()
        {
            List<Company> cathedras = await _companyRepository.GetAll() as List<Company>;

            ShowCathedrasAdminView result = _cathedraMapper.MapAllCathedrasToViewModel(cathedras);

            return result;
        }

        public async Task<CreateCathedraDataAdminView> LoadDataForCreateCathedraPage()
        {
            var companies = await _companyRepository.GetAll() as List<Company>;

            var viewModel = new CreateCathedraDataAdminView();

            foreach (Company faculty in companies)
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
            Company cathedra = await _companyRepository.FindCompanyByName(viewModel.Name);

            if (!(cathedra is null))
            {
                throw new AdminException("Entered cathedra already exist.");
            }

            cathedra = _cathedraMapper.MapToCathedraModel(viewModel);

            await _companyRepository.Create(cathedra);
        }

        public async Task<EditCathedraDataAdminView> EditCathedra(int id)
        {
            Company cathedra = await _companyRepository.Get(id);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
            }

            var faculties = await _companyRepository.GetAll() as List<Test>;

            EditCathedraDataAdminView viewModel = _cathedraMapper.MapToEditCathedraDataModel(cathedra, faculties);

            return viewModel;
        }

        public async Task EditCathedra(EditCathedraAdminView viewModel)
        {
            Company cathedra = await _companyRepository.Get(viewModel.Id);

            if (cathedra is null)
            {
                throw new AdminException("Entered cathedra doesn't exist.");
            }

            var changeCiphers = false;

            if (!(cathedra.Name.ToUpper().Equals(viewModel.Name.ToUpper())))
            {
                cathedra = await _companyRepository.FindCompanyByName(viewModel.Name);

                if (!(cathedra is null))
                {
                    throw new AdminException("Entered cathedra already exist.");
                }
            }

            _cathedraMapper.MapCathedraEditViewModelToCathedraModel(cathedra, viewModel);

            await _companyRepository.Update(cathedra);
        }

        public async Task DeleteCathedra(int id)
        {
            Company cathedra = await _companyRepository.Get(id);

            if (cathedra is null)
            {
                throw new AdminException("Selected cathedra doesn't exist.");
            }

            await _companyRepository.Delete(id);
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
            List<Teacher> teachers = await _teacherRepository.GetAllTeachersByCompany(ApplicationConstants.CurrentCompanyId);

            ShowTeachersAdminView result = _teacherMapper.MapTeacherModelsToViewModels(teachers);

            return result;
        }

        public async Task<RegisterNewTeacherUserDataAccountView> LoadDataForRegisterTeacherPage()
        {
            var result = new RegisterNewTeacherUserDataAccountView();

            return result;
        }

        public async Task RegisterTeacher(RegisterNewTeacherUserAccountView viewModel)
        {
            var companies = _companyRepository.GetAll();
            if (companies.Result == null || companies.Result.ToList().Count == 0)
            {
                Company company = new Company() { Name = "Test" };
                await _companyRepository.Create(company);

                ApplicationConstants.CurrentCompanyId = company.Id;
            }

            var teacher = new Teacher();

            teacher.Email = viewModel.Email;
            teacher.UserName = viewModel.Username;
            teacher.CompanyId = ApplicationConstants.CurrentCompanyId;

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AdminException("Passwords are different");
            }

            if (!(await _userManager.FindByEmailAsync(viewModel.Email) is null) || !(await _userManager.FindByNameAsync(viewModel.Username) is null))
            {
                throw new AdminException("Account with such Email or UserID already exists");
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
        }

        public async Task<EditTeacherDataAccountView> LoadDataForEditTeacherAccount(string userName)
        {
            Teacher teacher = await _teacherRepository.GetTeacherByName(userName);

            if (teacher is null)
            {
                throw new AdminException("User not found");
            }

            EditTeacherDataAccountView viewModel = _teacherMapper.MapEditTeacherModelsToEditViewModels(teacher);

            return viewModel;
        }

        public async Task EditTeacherInformation(EditTeacherInformationView viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username) as Teacher;

            if (user is null)
            {
                throw new AdminException("User not found.");
            }

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MiddleName = viewModel.MiddleName;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.BirthDate = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.BirthDate).Value;

            user.AddressLine = viewModel.AddressLine;
            
            await _userManager.UpdateAsync(user);
        }
        #endregion

        #region Students
        public async Task<ShowStudentsAdminView> ShowStudents()
        {
            List<Student> teachers = await _studentRepository.GetAllStudentsByCompany(ApplicationConstants.CurrentCompanyId);

            ShowStudentsAdminView result = _studentMapper.MapStudentModelsToViewModels(teachers);

            return result;
        }

        public async Task<RegisterNewStudentUserDataAccountView> LoadDataForRegisterStudentPage()
        {
            var result = new RegisterNewStudentUserDataAccountView();

            return result;
        }

        public async Task RegisterStudent(RegisterNewStudentUserAccountView viewModel)
        {
            var companies = _companyRepository.GetAll();
            if (companies.Result == null || companies.Result.ToList().Count == 0)
            {
                Company company = new Company() { Name = "Test" };
                await _companyRepository.Create(company);

                ApplicationConstants.CurrentCompanyId = company.Id;
            }

            var teacher = new Student();

            teacher.Email = viewModel.Email;
            teacher.UserName = viewModel.Username;
            teacher.CompanyId = ApplicationConstants.CurrentCompanyId;

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AdminException("Passwords are different");
            }

            if (!(await _userManager.FindByEmailAsync(viewModel.Email) is null) || !(await _userManager.FindByNameAsync(viewModel.Username) is null))
            {
                throw new AdminException("Account with such Email or UserID already exists");
            }

            teacher.BirthDate = _dateParseHelper.ParseStringToDatetime(viewModel.BirthDate);

            _accountMapper.MapStudentViewModelToModel(viewModel, teacher);
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

            await _userManager.AddToRoleAsync(registeredTeacher, ApplicationConstants.USER_ROLE);
        }

        public async Task<EditStudentDataAccountView> LoadDataForEditStudentAccount(string userName)
        {
            Student teacher = await _studentRepository.GetStudentByName(userName);

            if (teacher is null)
            {
                throw new AdminException("User not found");
            }

            EditStudentDataAccountView viewModel = _studentMapper.MapEditStudentModelsToEditViewModels(teacher);

            return viewModel;
        }

        public async Task EditStudentInformation(EditStudentInformationView viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username) as Student;

            if (user is null)
            {
                throw new AdminException("User not found.");
            }

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MiddleName = viewModel.MiddleName;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.BirthDate = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.BirthDate).Value;

            user.AddressLine = viewModel.AddressLine;

            await _userManager.UpdateAsync(user);
        }
        #endregion
    }
}