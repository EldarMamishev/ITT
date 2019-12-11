using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.CathedraViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface ICompanyMapper
    {
        ShowCathedrasAdminView MapAllCathedrasToViewModel(List<Company> model);
        Company MapToCathedraModel(CreateCathedraAdminView viewModel);
        EditCathedraDataAdminView MapToEditCathedraDataModel(Company model, List<Test> faculties);
        void MapCathedraEditViewModelToCathedraModel(Company model, EditCathedraAdminView viewModel);
    }
}