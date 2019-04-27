using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace UniversityProject.WEB.Controllers.Base
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected string UserName => User.Claims.FirstOrDefault(item => item.Type == ClaimTypes.Name)?.Value;
        protected List<string> UserRoles => User.Claims.Where(item => item.Type == ClaimTypes.Role)?.Select(item => item.Value).ToList();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewData["UserName"] = UserName;
        }
    }
}