using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.Faculty;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface IFacultyMapper
    {
        Faculty MapToFacultyModel(CreateFacultyAdminView viewModel);
        ShowFacultiesAdminView MapAllFacultiesToViewModel(List<Faculty> faculties);
        EditFacultyAdminView MapToEditFacultyViewModel(Faculty model);
        void MapFacultyEditViewModelToFacultyModel(Faculty model, EditFacultyAdminView viewModel);
    }
}