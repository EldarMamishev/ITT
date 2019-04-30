using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UniversityProject.BusinessLogic.Fabrics.Interfaces;
using UniversityProject.ViewModels.MenuViewModels;

namespace UniversityProject.WEB.Controllers.Base
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        #region Properties & Variables
        protected string UserName => User.Claims.FirstOrDefault(item => item.Type == ClaimTypes.Name)?.Value;
        protected List<string> UserRoles => User.Claims.Where(item => item.Type == ClaimTypes.Role)?.Select(item => item.Value).ToList();

        private IMenuItemsFabric _menuItemsFabric;
        #endregion

        #region Constructors
        public BaseController(IMenuItemsFabric menuItemsFabric)
        {
            _menuItemsFabric = menuItemsFabric;
        }
        #endregion

        #region Override Methods
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewData["UserName"] = UserName;

            MenuViewModel menu = _menuItemsFabric.BuildMenu();

            ViewData["UserName"] = UserName;

            ViewData["Menu"] = menu;

            ViewData["BaseUserRole"] = UserRoles.LastOrDefault();
        }
        #endregion
    }
}