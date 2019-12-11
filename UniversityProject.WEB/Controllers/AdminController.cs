using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BaseExceptions;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;
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

        #region Cathedras
        [HttpGet]
        public async Task<IActionResult> ShowCathedras()
        {
            ShowCathedrasAdminView result = await _adminService.ShowCathedras();

            return View(viewName: "Cathedras/Cathedras", result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCathedra()
        {
            CreateCathedraDataAdminView result = await _adminService.LoadDataForCreateCathedraPage();

            return View("Cathedras/CreateCathedra", result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCathedra(CreateCathedraAdminView viewModel)
        {
            try
            {
                await _adminService.CreateCathedra(viewModel);

                return RedirectToAction("ShowCathedras");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                CreateCathedraDataAdminView result = await _adminService.LoadDataForCreateCathedraPage();

                return View("Cathedras/CreateCathedra", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditCathedra(int id)
        {
            EditCathedraDataAdminView result = await _adminService.EditCathedra(id);

            return View("Cathedras/EditCathedra", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditCathedra(EditCathedraAdminView viewModel)
        {
            try
            {
                await _adminService.EditCathedra(viewModel);

                return RedirectToAction("ShowCathedras");
            }
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                EditCathedraDataAdminView result = await _adminService.EditCathedra(viewModel.Id);

                return View("Cathedras/EditCathedra", result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCathedra(int id)
        {
            try
            {
                await _adminService.DeleteCathedra(id);

                return new JsonResult(new OkResult());
            }
            catch (AdminException)
            {
                return RedirectToAction("ShowCathedras");
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

                return View(viewName: "Teachers/RegisterNewTeacher");
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
        #endregion

        #region Students

        #endregion

        #endregion
    }
}