using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityProject.WEB.Controllers.Base;
using UniversityProject.WEB.Models;

namespace UniversityProject.WEB.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (UserRoles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
