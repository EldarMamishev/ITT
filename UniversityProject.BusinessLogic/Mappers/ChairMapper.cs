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
    }
}