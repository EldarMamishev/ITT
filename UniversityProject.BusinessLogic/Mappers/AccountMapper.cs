using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AccountViewModels;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class AccountMapper : IAccountMapper
    {
        public void MapFinishRegistrationAndConfirmAccountToApplicationUser(FinishRegistrationAndConfirmAccountAccountView viewModel, Student model)
        {
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            model.MiddleName = viewModel.MiddleName;
            model.BirthDate = viewModel.BirthDate;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.ParentsPhoneNumber = viewModel.ParentsPhoneNumber;
            model.Country = viewModel.Country;
            model.City = viewModel.City;
            model.AddressLine = viewModel.AddressLine;
        }

        public void MapTeacherViewModelToModel(RegisterNewTeacherUserAccountView viewModel, Teacher model)
        {
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            model.MiddleName = viewModel.MiddleName;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.Country = viewModel.Country;
            model.City = viewModel.City;
            model.AddressLine = viewModel.AddressLine;
            model.CathedraId = viewModel.CathedraId;
        }
    }
}