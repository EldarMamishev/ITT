using System.Collections.Generic;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class CathedraMapper : ICathedraMapper
    {
        public ShowCathedrasAdminView MapAllCathedrasToViewModel(List<Cathedra> model)
        {
            var viewModel = new ShowCathedrasAdminView();

            foreach (Cathedra cathedra in model)
            {
                var item = new ShowCathedrasAdminViewItem();

                item.Id = cathedra.Id;
                item.Name = cathedra.Name;
                item.Cipher = cathedra.Cipher;
                item.FacultyName = !(cathedra.Faculty is null) ? cathedra.Faculty.Name : "";

                viewModel.Cathedras.Add(item);
            }

            return viewModel;
        }

        public Cathedra MapToCathedraModel(CreateCathedraAdminView viewModel)
        {
            var model = new Cathedra();

            model.Name = viewModel.Name;
            model.Cipher = viewModel.Cipher;
            model.FacultyId = viewModel.FacultyId;

            return model;
        }

        public EditCathedraDataAdminView MapToEditCathedraDataModel(Cathedra model, List<Faculty> faculties)
        {
            var viewModel = new EditCathedraDataAdminView();

            viewModel.Id = model.Id;
            viewModel.Name = model.Name;
            viewModel.Cipher = model.Cipher;
            viewModel.FacultyId = model.FacultyId is null ? 0 : model.FacultyId.Value;

            foreach (Faculty faculty in faculties)
            {
                var viewItem = new EditCathedraDataAdminViewItem();

                viewItem.Id = faculty.Id;
                viewItem.FacultyName = faculty.Name;

                viewModel.Faculties.Add(viewItem);
            }

            return viewModel;
        }

        public void MapCathedraEditViewModelToCathedraModel(Cathedra model, EditCathedraAdminView viewModel)
        {
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            model.Cipher = viewModel.Cipher;
            model.FacultyId = viewModel.FacultyId;
        }
    }
}