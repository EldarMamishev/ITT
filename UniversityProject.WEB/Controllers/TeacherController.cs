using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.BusinessLogic.Services.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.WEB.Controllers.Base;

namespace UniversityProject.WEB.Controllers
{
    public class TeacherController : BaseController
    {
        #region Properties
        private ITeacherService _teacherService;
        #endregion

        #region Constructors
        public TeacherController(ITeacherService teacherService, IMenuItemsFabric menuItemsFabric) 
            : base(menuItemsFabric)
        {
            _teacherService = teacherService;
        }
        #endregion

        [Authorize(Roles = ApplicationConstants.TEACHER_ROLE)]
        public IActionResult Index()
        {
            return View();
        }


    }
}