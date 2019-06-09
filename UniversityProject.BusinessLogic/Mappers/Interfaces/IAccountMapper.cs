using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AccountViewModels;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface IAccountMapper
    {
        void MapFinishRegistrationAndConfirmAccountToApplicationUser(FinishRegistrationAndConfirmAccountAccountView mapFrom, Student mapTo);
        void MapTeacherViewModelToModel(RegisterNewTeacherUserAccountView viewModel, Teacher model);
    }
}