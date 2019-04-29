using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AccountViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface IAccountMapper
    {
        void MapFinishRegistrationAndConfirmAccountToApplicationUser(FinishRegistrationAndConfirmAccountAccountView mapFrom, Student mapTo);
    }
}