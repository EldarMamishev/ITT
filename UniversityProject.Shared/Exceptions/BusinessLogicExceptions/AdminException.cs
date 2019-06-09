using UniversityProject.Shared.Exceptions.BaseExceptions;

namespace UniversityProject.Shared.Exceptions.BusinessLogicExceptions
{
    public class AdminException : BaseException
    {
        public AdminException(string message) : base(message)
        {
        }
    }
}