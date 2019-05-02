using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Constants;
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
            await _adminService.CreateFaculty(viewModel);

            return RedirectToAction("ShowFaculties");
        }
        #endregion
    }
}