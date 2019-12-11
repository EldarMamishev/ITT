using System.Collections.Generic;
using System.Linq;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class TeacherMapper : ITeacherMapper
    {
        public ShowTeachersAdminView MapTeacherModelsToViewModels(List<Teacher> model)
        {
            var viewModel = new ShowTeachersAdminView();

            foreach (Teacher teacher in model)
            {
                var viewModelItem = new TeacherShowTeachersAdminViewItem();
                viewModelItem.UserName = teacher.UserName;
                viewModelItem.FullName = $"{teacher.LastName} {teacher.FirstName} {teacher.MiddleName}";

                viewModel.Teachers.Add(viewModelItem);
            }

            return viewModel;
        }

        public void MapAllCathedrasToViewModel(List<Company> cathedras, RegisterNewTeacherUserDataAccountView viewModel)
        {
            foreach (Company cathedra in cathedras)
            {
                var cathedraViewItem = new CathedraRegisterNewTeacherUserDataAccountViewItem();

                cathedraViewItem.Id = cathedra.Id;
                cathedraViewItem.Name = cathedra.Name;

                viewModel.Cathedras.Add(cathedraViewItem);
            }
        }

        public EditTeacherDataAccountView MapEditTeacherModelsToEditViewModels(Teacher teacher)
        {
            var viewModel = new EditTeacherDataAccountView();

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