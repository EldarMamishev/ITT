using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AccountViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class AccountMapper : IAccountMapper
    {
        public void MapFinishRegistrationAndConfirmAccountToApplicationUser(FinishRegistrationAndConfirmAccountAccountView mapFrom, Student mapTo)
        {
            mapTo.FirstName = mapFrom.FirstName;
            mapTo.LastName = mapFrom.LastName;
            mapTo.MiddleName = mapFrom.MiddleName;
            mapTo.BirthDate = mapFrom.BirthDate;
            mapTo.PhoneNumber = mapFrom.PhoneNumber;
            mapTo.ParentsPhoneNumber = mapFrom.ParentsPhoneNumber;
            mapTo.Country = mapFrom.Country;
            mapTo.City = mapFrom.City;
            mapTo.AddressLine = mapFrom.AddressLine;
        }
    }
}