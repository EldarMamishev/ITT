using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class FacultyMapper : IFacultyMapper
    {
        public Faculty MapToFacultyModel(CreateFacultyAdminView viewModel)
        {
            var faculty = new Faculty();

            faculty.Name = viewModel.Name;
            faculty.Cipher = viewModel.Cipher;
            faculty.Address = viewModel.Address;
            faculty.PhoneNumber = viewModel.PhoneNumber;
            faculty.StudentsCount = viewModel.StudentsCount;

            return faculty;
        }
    }
}