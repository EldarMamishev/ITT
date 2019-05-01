using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.WEB.Controllers.Base;

namespace UniversityProject.WEB.Controllers
{
    [Authorize(Roles = ApplicationConstants.ADMIN_ROLE)]
    public class AdminController : BaseController
    {
        #region Constructors
        public AdminController(IMenuItemsFabric menuItemsFabric) : base(menuItemsFabric)
        {
        }
        #endregion

        #region Public Methods   
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowFaculties()
        {
            return View(viewName: "Faculty");
        }

        #endregion
    }
}