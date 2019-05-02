using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.Faculty;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowFaculties()
        {
            ShowFacultiesAdminView result = await _adminService.ShowFaculties();

            return View(viewName: "Faculty", result);
        }

        [HttpGet]
        public IActionResult CreateFaculty()
        {
            return View();
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
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditFaculty(int id)
        {
            EditFacultyAdminView result = await _adminService.EditFaculty(id);

            return View(result);
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
                return View();
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
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
        #endregion
    }
}