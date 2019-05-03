using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;
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
                return View("Faculties/EditFaculty", viewModel);
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
                return View("Faculties/ShowFaculties");
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
                return View("Chairs/EditChair", viewModel);
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
            catch (AdminException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Chairs/ShowChairs");
            }
        }
        #endregion

        #endregion
    }
}