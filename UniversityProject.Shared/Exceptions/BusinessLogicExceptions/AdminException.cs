using System;

namespace UniversityProject.Shared.Exceptions.BusinessLogicExceptions
{
    public class AdminException : Exception
    {
        public AdminException(string message) : base(message)
        {
        }
    }
}