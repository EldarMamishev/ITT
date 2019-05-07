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
            var model = new Faculty();

            model.Name = viewModel.Name;
            model.Cipher = viewModel.Cipher;
            model.Address = viewModel.Address;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.StudentsCount = viewModel.StudentsCount;

            return model;
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

        public EditFacultyAdminView MapToEditFacultyViewModel(Faculty model)
        {
            var viewModel = new EditFacultyAdminView();

            viewModel.Id = model.Id;
            viewModel.Name = model.Name;
            viewModel.Cipher = model.Cipher;
            viewModel.Address = model.Address;
            viewModel.PhoneNumber = model.PhoneNumber;
            viewModel.StudentsCount = model.StudentsCount;

            return viewModel;
        }

        public void MapFacultyEditViewModelToFacultyModel(Faculty model, EditFacultyAdminView viewModel)
        {
            model.Name = viewModel.Name;
            model.Cipher = viewModel.Cipher;
            model.Address = viewModel.Address;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.StudentsCount = viewModel.StudentsCount;
        }
    }
}