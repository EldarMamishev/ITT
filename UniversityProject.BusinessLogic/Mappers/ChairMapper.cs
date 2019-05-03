using System.Collections.Generic;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class ChairMapper : IChairMapper
    {
        public ShowChairsAdminView MapAllChairsToViewModel(List<Chair> model)
        {
            var viewModel = new ShowChairsAdminView();

            foreach (Chair chair in model)
            {
                var item = new ShowChairsAdminViewItem();

                item.Id = chair.Id;
                item.Name = chair.Name;
                item.Cipher = chair.Cipher;
                item.FacultyName = !(chair.Faculty is null) ? chair.Faculty.Name : "";

                viewModel.Chairs.Add(item);
            }

            return viewModel;
        }

        public Chair MapToChairModel(CreateChairAdminView viewModel)
        {
            var model = new Chair();

            model.Name = viewModel.Name;
            model.Cipher = viewModel.Cipher;
            model.FacultyId = viewModel.FacultyId;

            return model;
        }

        public EditChairDataAdminView MapToEditChairDataModel(Chair model, List<Faculty> faculties)
        {
            var viewModel = new EditChairDataAdminView();

            viewModel.Id = model.Id;
            viewModel.Name = model.Name;
            viewModel.Cipher = model.Cipher;
            viewModel.FacultyId = model.FacultyId is null ? 0 : model.FacultyId.Value;

            foreach (Faculty faculty in faculties)
            {
                var viewItem = new EditChairDataAdminViewItem();

                viewItem.Id = faculty.Id;
                viewItem.FacultyName = faculty.Name;

                viewModel.Faculties.Add(viewItem);
            }

            return viewModel;
        }

        public void MapChairEditViewModelToChairModel(Chair model, EditChairAdminView viewModel)
        {
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            model.Cipher = viewModel.Cipher;
            model.FacultyId = viewModel.FacultyId;
        }
    }
}