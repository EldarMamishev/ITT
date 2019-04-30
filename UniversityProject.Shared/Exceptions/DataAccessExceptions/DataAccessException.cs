using System;

namespace UniversityProject.Shared.Exceptions.DataAccessExceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message)
        {
        }
    }
}