using System;

namespace UniversityProject.Shared.Exceptions.BaseExceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}