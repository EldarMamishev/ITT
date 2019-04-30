using System;

namespace UniversityProject.Shared.Exceptions.BusinessLogicExceptions
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message)
        {
        }
    }
}