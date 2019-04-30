using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.WEB.Controllers.Base;

namespace UniversityProject.WEB.Controllers
{
    public class AdminController : BaseController
    {
        #region Constructors
        public AdminController(IMenuItemsFabric menuItemsFabric) : base(menuItemsFabric)
        {
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}