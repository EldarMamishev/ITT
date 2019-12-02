using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface ICathedraMapper
    {
        ShowCathedrasAdminView MapAllCathedrasToViewModel(List<Cathedra> model);
        Cathedra MapToCathedraModel(CreateCathedraAdminView viewModel);
        EditCathedraDataAdminView MapToEditCathedraDataModel(Cathedra model, List<Faculty> faculties);
        void MapCathedraEditViewModelToCathedraModel(Cathedra model, EditCathedraAdminView viewModel);
    }
}