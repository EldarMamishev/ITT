using UniversityProject.Shared.Exceptions.BaseExceptions;

namespace UniversityProject.Shared.Exceptions.BusinessLogicExceptions
{
    public class DateParseException : BaseException
    {
        public DateParseException(string message) : base(message)
        {
        }
    }
}