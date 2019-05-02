using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.ChairViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface IChairMapper
    {
        ShowChairsAdminView MapAllChairsToViewModel(List<Chair> model);
        Chair MapToChairModel(CreateChairAdminView viewModel);
    }
}