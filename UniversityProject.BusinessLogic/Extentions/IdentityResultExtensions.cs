using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace UniversityProject.BusinessLogic.Extentions
{
    public static class IdentityResultExtensions
    {
        public static string GetFirstError(this IdentityResult result)
        {
            return result.Errors.FirstOrDefault()?.Description;
        }
    }
}