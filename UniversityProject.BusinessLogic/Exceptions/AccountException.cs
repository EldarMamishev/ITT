using System;

namespace UniversityProject.BusinessLogic.Exceptions
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message)
        {
        }
    }
}