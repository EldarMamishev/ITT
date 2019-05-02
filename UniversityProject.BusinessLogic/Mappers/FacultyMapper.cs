using System.Collections.Generic;
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

        public ShowFacultiesAdminView MapAllFacultiesToViewModel(List<Faculty> faculties)
        {
            var returnViewModel = new ShowFacultiesAdminView();

            foreach (Faculty faculty in faculties)
            {
                var item = new ShowFacultiesAdminViewItem();

                item.Id = faculty.Id;
                item.Name = faculty.Name;
                item.Cipher = faculty.Cipher;
                item.Address = faculty.Address;
                item.PhoneNumber = faculty.PhoneNumber;
                item.StudentsCount = faculty.StudentsCount;

                returnViewModel.Faculties.Add(item);
            }

            return returnViewModel;
        }
    }
}