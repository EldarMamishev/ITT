using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.StudentViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class StudentMapper : IStudentMapper
    {
        public ShowStudentsAdminView MapStudentModelsToViewModels(List<Student> model)
        {
            var viewModel = new ShowStudentsAdminView();

            foreach (Student teacher in model)
            {
                var viewModelItem = new StudentShowStudentsAdminViewItem();
                viewModelItem.UserName = teacher.UserName;
                viewModelItem.FullName = $"{teacher.LastName} {teacher.FirstName} {teacher.MiddleName}";

                viewModel.Students.Add(viewModelItem);
            }

            return viewModel;
        }

        public EditStudentDataAccountView MapEditStudentModelsToEditViewModels(Student teacher)
        {
            var viewModel = new EditStudentDataAccountView();

            viewModel.Id = teacher.Id;
            viewModel.FirstName = teacher.FirstName;
            viewModel.LastName = teacher.LastName;
            viewModel.MiddleName = teacher.MiddleName;
            viewModel.PhoneNumber = teacher.PhoneNumber;
            viewModel.BirthDate = teacher.BirthDate.ToString("yyyy");
            viewModel.Username = teacher.UserName;
            viewModel.Email = teacher.Email;
            viewModel.AddressLine = teacher.AddressLine;
            viewModel.CathedraId = teacher.CompanyId;

            return viewModel;
        }
    }
}
