using UniversityProject.Shared.Exceptions.BaseExceptions;

namespace UniversityProject.Shared.Exceptions.BusinessLogicExceptions
{
    public class AccountException : BaseException
    {
        public AccountException(string message) : base(message)
        {
        }
    }
}