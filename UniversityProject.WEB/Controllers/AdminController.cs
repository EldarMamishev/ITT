using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BaseExceptions;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;
using UniversityProject.ViewModels.Faculty;
using UniversityProject.WEB.Attributes.ErrorHandleAttribute;
using UniversityProject.WEB.Controllers.Base;

namespace UniversityProject.WEB.Controllers
{
    [Authorize(Roles = ApplicationConstants.ADMIN_ROLE)]
    public class AdminController : BaseController
    {
        #region Properties
        private IAdminService _adminService;
        #endregion

        #region Constructors
        public AdminController(IAdminService adminService, IMenuItemsFabric menuItemsFabric) : base(menuItemsFabric)
        {
            _adminService = adminService;
        }
        #endregion

        #region Public Methods   

        #region Home
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Faculties
        [HttpGet]
        public async Task<IActionResult> ShowFaculties()
        {
            ShowFacultiesAdminView result = await _adminService.ShowFaculties();

            return View(viewName: "Faculties/Faculties", result);
        }

        [HttpGet]
        public IActionResult CreateFaculty()
        {
            return View("Faculties/CreateFaculty");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaculty(CreateFacultyAdminView viewModel)
        {
            try
            {
                await _adminService.CreateFaculty(viewModel);

                return RedirectToAction("ShowFaculties");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Faculties/CreateFaculty");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditFaculty(int id)
        {
            EditFacultyAdminView result = await _adminService.EditFaculty(id);

            return View("Faculties/EditFaculty", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditFaculty(EditFacultyAdminView viewModel)
        {
            try
            {
                await _adminService.EditFaculty(viewModel);

                return RedirectToAction("ShowFaculties");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                EditFacultyAdminView result = await _adminService.EditFaculty(viewModel.Id);

                return View("Faculties/EditFaculty", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            try
            {
                await _adminService.DeleteFaculty(id);

                return new JsonResult(new OkResult());
            }
            catch (AdminException)
            {
                return RedirectToAction("ShowFaculties");
            }
        }
        #endregion

        #region Chairs
        [HttpGet]
        public async Task<IActionResult> ShowChairs()
        {
            ShowChairsAdminView result = await _adminService.ShowChairs();

            return View(viewName: "Chairs/Chairs", result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateChair()
        {
            CreateChairDataAdminView result = await _adminService.LoadDataForCreateChairPage();

            return View("Chairs/CreateChair", result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChair(CreateChairAdminView viewModel)
        {
            try
            {
                await _adminService.CreateChair(viewModel);

                return RedirectToAction("ShowChairs");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                CreateChairDataAdminView result = await _adminService.LoadDataForCreateChairPage();

                return View("Chairs/CreateChair", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditChair(int id)
        {
            EditChairDataAdminView result = await _adminService.EditChair(id);

            return View("Chairs/EditChair", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditChair(EditChairAdminView viewModel)
        {
            try
            {
                await _adminService.EditChair(viewModel);

                return RedirectToAction("ShowChairs");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                EditChairDataAdminView result = await _adminService.EditChair(viewModel.Id);

                return View("Chairs/EditChair", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteChair(int id)
        {
            try
            {
                await _adminService.DeleteChair(id);

                return new JsonResult(new OkResult());
            }
            catch (AdminException)
            {
                return RedirectToAction("ShowChairs");
            }
        }
        #endregion

        #region Groups
        [HttpGet]
        public async Task<IActionResult> ShowGroups()
        {
            ShowGroupsAdminView result = await _adminService.ShowGroups();

            return View(viewName: "Groups/Groups", result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGroup()
        {
            CreateGroupDataAdminView result = await _adminService.LoadDataForCreateGroupPage();

            return View("Groups/CreateGroup", result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupAdminView viewModel)
        {
            try
            {
                await _adminService.CreateGroup(viewModel);

                return RedirectToAction("ShowGroups");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                CreateGroupDataAdminView result = await _adminService.LoadDataForCreateGroupPage();

                return View("Groups/CreateGroup", result);
            }
        }

        [HttpGet]
        public async Task<JsonResult> LoadChairsByFacultyId(int facultyId)
        {
            JsonResult result = await _adminService.LoadChairsByFacultyId(facultyId);

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> EditGroup(int id)
        {
            EditGroupDataAdminView result = await _adminService.EditGroup(id);

            return View("Groups/EditGroup", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditGroup(EditGroupAdminView viewModel)
        {
            try
            {
                await _adminService.EditGroup(viewModel);

                return RedirectToAction("ShowGroups");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                EditGroupDataAdminView result = await _adminService.EditGroup(viewModel.Id);

                return View("Groups/EditGroup", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                await _adminService.DeleteGroup(id);

                return new JsonResult(new OkResult());
            }
            catch (AdminException)
            {
                return RedirectToAction("ShowGroups");
            }
        }
        #endregion

        #region Subjects
        [HttpGet]
        public async Task<IActionResult> ShowSubjects()
        {
            ShowSubjectsAdminView result = await _adminService.ShowSubjects();

            return View(viewName: "Subjects/Subjects", result);
        }

        [ValidateErrorHandlerFilter]
        [HttpGet]
        public async Task<JsonResult> CreateSubject(string subjectName)
        {
            ResponseSubjectView result = await _adminService.CreateSubject(subjectName);

            return new JsonResult(result);
        }

        [ValidateErrorHandlerFilter]
        [HttpPost]
        public async Task<JsonResult> EditSubject([FromBody]RequestSubjectView requestViewModel)
        {
            ResponseSubjectView result = await _adminService.EditSubject(requestViewModel);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                await _adminService.DeleteSubject(id);

                return new JsonResult(new OkResult());
            }
            catch (AdminException)
            {
                return RedirectToAction("ShowSubjects");
            }
        }
        #endregion

        #region Teachers
        [HttpGet]
        public async Task<IActionResult> ShowTeachers()
        {
            ShowTeachersAdminView result = await _adminService.ShowTeachers();

            return View(viewName: "Teachers/Teachers", result);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTeacher()
        {
            RegisterNewTeacherUserDataAccountView result = await _adminService.LoadDataForRegisterTeacherPage();

            return View(viewName: "Teachers/RegisterNewTeacher", result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterNewTeacherUserAccountView viewModel)
        {
            try
            {
                await _adminService.RegisterTeacher(viewModel);

                return RedirectToAction("ShowTeachers");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                RegisterNewTeacherUserDataAccountView result = await _adminService.LoadDataForRegisterTeacherPage();

                return View(viewName: "Teachers/RegisterNewTeacher", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTeacherAccount(string userName)
        {
            EditTeacherDataAccountView result = await _adminService.LoadDataForEditTeacherAccount(userName);

            return View(viewName: "Teachers/EditTeacherAccount", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeacherInformation(EditTeacherInformationView viewModel)
        {
            try
            {
                await _adminService.EditTeacherInformation(viewModel);

                return await EditTeacherAccount(viewModel.Username);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                EditTeacherDataAccountView result = await _adminService.LoadDataForEditTeacherAccount(viewModel.Username);

                return View(viewName: "Teachers/EditTeacherAccount", result);
            }

        }

        [ValidateErrorHandlerFilter]
        [HttpPost]
        public async Task<JsonResult> AddSubjectToTeacher([FromBody]RequestAddSubjectToTeacherView requestViewModel)
        {
            ResponseAddSubjectToTeacherView result = await _adminService.AddSubjectToTeacher(requestViewModel);

            return new JsonResult(result);
        }

        [ValidateErrorHandlerFilter]
        [HttpPost]
        public async Task<IActionResult> DeleteSubjectFromTeacher([FromBody]RequestDeleteSubjectFromTeacherView requestViewModel)
        {
            await _adminService.DeleteSubjectFromTeacher(requestViewModel);

            return new JsonResult(new OkResult());
        }
        #endregion

        #region Journals
        #endregion

        #region Students
        #endregion

        [HttpGet]
        public IActionResult ShowScheduler()
        {
            return View(viewName: "Scheduler/Scheduler");
        }

        [HttpGet]
        public IActionResult ShowJournals()
        {
            return View(viewName: "Journals/Journals");
        }
        #endregion
    }
}