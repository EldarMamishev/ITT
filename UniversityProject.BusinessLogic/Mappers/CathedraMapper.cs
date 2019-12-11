using System.Collections.Generic;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class CompanyMapper : ICompanyMapper
    {
        public ShowCathedrasAdminView MapAllCathedrasToViewModel(List<Company> model)
        {
            var viewModel = new ShowCathedrasAdminView();

            foreach (Company cathedra in model)
            {
                var item = new ShowCathedrasAdminViewItem();

                item.Id = cathedra.Id;
                item.Name = cathedra.Name;

                viewModel.Cathedras.Add(item);
            }

            return viewModel;
        }

        public Company MapToCathedraModel(CreateCathedraAdminView viewModel)
        {
            var model = new Company();

            model.Name = viewModel.Name;

            return model;
        }

        public EditCathedraDataAdminView MapToEditCathedraDataModel(Company model, List<Test> faculties)
        {
            var viewModel = new EditCathedraDataAdminView();

            viewModel.Id = model.Id;
            viewModel.Name = model.Name;

            foreach (Test faculty in faculties)
            {
                var viewItem = new EditCathedraDataAdminViewItem();

                viewItem.Id = faculty.Id;
                viewItem.FacultyName = faculty.Name;

                viewModel.Faculties.Add(viewItem);
            }

            return viewModel;
        }

        public void MapCathedraEditViewModelToCathedraModel(Company model, EditCathedraAdminView viewModel)
        {
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
        }
    }
}